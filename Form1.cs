using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Diagnostics;
using System.Runtime.Serialization;
using ImageSlicer;

namespace Cropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Panels added to the image
        /// </summary>
        List<SelectionPanel> _selectionPanels;

        /// <summary>
        /// Panel hit detection
        /// </summary>
        SelectionPanel _panelDown;
        SelectionPartHit _panelPartDown;
        SelectionPanel _panelOver;
        SelectionPartHit _panelPartOver;
        SelectionPanel _selectedPanel;

        Point _dragOffset;  //when mouse down occurs in a panel, record it's position relative to the panel origin

        /// <summary>
        /// Mouse operations
        /// </summary>
        bool _IsMouseDown;
        Point _mouseDownLocation;
        Rectangle _SelectionRectangle;

        /// <summary>
        /// When drawing a selection rectangle
        /// </summary>
        Pen _selectPen = new Pen(Color.Blue, 5) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

        /// <summary>
        /// Source of the image
        /// </summary>
        string _imageSourceFolder;


        private bool _imageLoaded => pictureBox1.Image != null;


        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //pictureBox1.Image = new Bitmap(@"C:\Users\andy\Pictures\Scans\Viz59\ColditsKids\Colditz Kids.png");
            //_selectionPanels = new List<SelectionPanel>();
            pictureBox1.Invalidate();
        }

        #region Picturebox Events

        /// <summary>
        /// Draw the picture box contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!_imageLoaded) return;

            foreach (SelectionPanel s in _selectionPanels)
            {
                s.Draw(e.Graphics);
            }

            if (!_SelectionRectangle.IsEmpty)
            {
                e.Graphics.DrawRectangle(_selectPen, _SelectionRectangle);
            }
        }

        /// <summary>
        /// Check for collision with a shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_imageLoaded) return;

            _IsMouseDown = true;
            _mouseDownLocation = new Point(e.X, e.Y);

            if (_panelOver != null)
            {
                _selectedPanel = _panelDown = _panelOver;
                _panelPartDown = _panelPartOver;
                _dragOffset = new Point(e.X - _panelDown.Location.X, e.Y - _panelDown.Location.Y);
                _selectionPanels.Where(s => s != _selectedPanel).ToList().ForEach(s => s.Unselect());
            }
            else
            {
                _selectedPanel = _panelOver = _panelDown = null;
                _panelPartDown = _panelPartDown = SelectionPartHit.none;
                _dragOffset = Point.Empty;

                _selectionPanels.ForEach(s => s.Unselect());
                pictureBox1.Invalidate();
            }


            propertyGrid1.SelectedObject = _selectedPanel;
            propertyGrid1.Refresh();

        }

        /// <summary>
        /// Drag the selected shape, if there is one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (!_imageLoaded) return;
            if (!_IsMouseDown)
            {

                _panelDown = _panelOver = null;
                _panelPartOver = SelectionPartHit.none;
                foreach (SelectionPanel selection in _selectionPanels)
                {
                    if (selection.IsHit(e.X, e.Y))
                    {
                        _panelOver = selection;
                        _panelPartOver = selection.ItemHit;
                        break;
                    }
                }

                if (_panelOver == null || _panelPartOver == SelectionPartHit.none)
                {
                    Cursor = Cursors.Default; // Change cursor back to default
                }
                else if (_panelPartOver == SelectionPartHit.body)
                {
                    Cursor = Cursors.SizeAll; // Change cursor when over the Selection rectangle
                }
                else if (_panelPartOver == SelectionPartHit.deletebutton)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.Cross; // Change cursor when over a handle   
                }

            }
            else
            {
                if (_panelDown == null) //we're drawing a pane
                {
                    int width = Math.Abs(e.X - _mouseDownLocation.X);
                    int height = Math.Abs(e.Y - _mouseDownLocation.Y);
                    int topLeftX = Math.Min(_mouseDownLocation.X, e.X);
                    int topLeftY = Math.Min(_mouseDownLocation.Y, e.Y);

                    _SelectionRectangle = new Rectangle(topLeftX, topLeftY, width, height);
                }
                else
                {
                    _SelectionRectangle = Rectangle.Empty;

                    switch (_panelPartDown)
                    {
                        case SelectionPartHit.body:
                            _panelDown.DragShape(e.X - _dragOffset.X, e.Y - _dragOffset.Y);
                            break;

                        default:
                            _panelDown.DragHandle(e.X, e.Y, _panelPartDown);
                            break;

                    }
                }

                pictureBox1.Invalidate();
            }
        }

        /// <summary>
        /// Mouse has gone up, maybe draw the selection rectanle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_imageLoaded) return;

            _IsMouseDown = false;

            if (!_SelectionRectangle.IsEmpty)
            {

                if (_SelectionRectangle.Width >= (int)selectionWidth.Value && _SelectionRectangle.Height >= (int)selectionHeight.Value)
                {
                    AddPanel(_SelectionRectangle.X, _SelectionRectangle.Y, _SelectionRectangle.Width, _SelectionRectangle.Height);
                }

                _SelectionRectangle = Rectangle.Empty;
                pictureBox1.Invalidate();

            }
        }

        /// <summary>
        /// Add a selection to the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!_imageLoaded) return;
            AddPanel(e.X, e.Y, (int)selectionWidth.Value, (int)selectionHeight.Value);
        }

        #endregion

        #region treeview code

        /// <summary>
        /// Add a panel into the treeview
        /// </summary>
        /// <param name="pNewPanel"></param>
        public void AddPanelToTree(SelectionPanel pNewPanel)
        {
            treeView1.Nodes.Add(pNewPanel.ID.ToString(), pNewPanel.Name);
        }

        /// <summary>
        /// Remove the specified panel from the treeview
        /// </summary>
        /// <param name="pPanel"></param>
        public void RemovePanel(SelectionPanel pPanel)
        {
            treeView1.Nodes.Remove
                (
                    treeView1.Nodes.Find(pPanel.ID.ToString(), false).First()
                );

            propertyGrid1.SelectedObject = null;
        }

        /// <summary>
        /// A node has been clocked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode n = treeView1.GetNodeAt(e.X, e.Y);

            if (n != null)
            {
                _selectedPanel = _panelDown = _panelOver = _selectionPanels.First(p => p.ID.ToString() == n.Name);
                _selectedPanel.ItemHit = SelectionPartHit.body;
                _panelPartDown = _panelPartOver = SelectionPartHit.body;
                propertyGrid1.SelectedObject = _selectedPanel;
                _selectionPanels.Where(s => s != _selectedPanel).ToList().ForEach(s => s.Unselect());
                pictureBox1.Invalidate();
            }
        }

        #endregion



        /// <summary>
        /// Add a panel onto the form
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void AddPanel(int x, int y, int w, int h)
        {
            var panel = new SelectionPanel(x, y, w, h);            
            panel.Order = _selectionPanels.Count;

            _selectionPanels.Add(panel);
            AddPanelToTree(panel);
            propertyGrid1.SelectedObject = _selectionPanels.Last();
            pictureBox1.Invalidate();

        }

        /// <summary>
        /// Export the images based on the selectionPanels
        /// </summary>
        /// <param name="outputDirectory"></param>
        public void ExportImages(string outputDirectory, int pStartNumber, string pImageName)
        {
            var sourceImage = pictureBox1.Image;



            foreach (SelectionPanel selection in _selectionPanels)
            {
                using (Bitmap croppedImage = new Bitmap(selection.PanelSize.Width, selection.PanelSize.Height))
                {
                    using (Graphics g = Graphics.FromImage(croppedImage))
                    {
                        // Draw the portion of the image within the rectangle onto the new bitmap
                        g.DrawImage(sourceImage, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height),
                            selection.Bounds, GraphicsUnit.Pixel);
                    }

                    // Save the cropped image to a file
                    string outputFilePath = Path.Combine(outputDirectory, $"{pImageName}_{selection.Order - 1 + pStartNumber}.png");
                    croppedImage.Save(outputFilePath, ImageFormat.Png);
                }
            }

            MessageBox.Show($"Exported {_selectionPanels.Count} panels to {outputDirectory}");
        }

        #region Linkbutton


        /// <summary>
        /// Autogenerate panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int imageWidth = pictureBox1.Size.Width;
            int imageHeight = pictureBox1.Size.Height;
            int padHorizontal = (int)padH.Value;
            int padVertical = (int)padV.Value;
            int rows = (int)numRows.Value;
            int cols = (int)numCols.Value;
            int order = (int)panelNumStart.Value;

            int panelWidth = (imageWidth - (padHorizontal * (cols + 1))) / rows;
            int panelHeight = (imageHeight - (padHorizontal * (rows + 1))) / cols;

            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {

                    int x = (c * padHorizontal) + (panelWidth * (c - 1));
                    int y = (r * padVertical) + (panelHeight * (r - 1));

                    Debug.WriteLine($"Cell [{r},{c}]: ({x},{y}) - ({panelWidth},{panelHeight})");

                    _selectionPanels.Add(

                            new SelectionPanel(x, y, panelWidth, panelHeight) { Order = order }

                        );

                    order++;

                    _selectionPanels.Last().Unselect();

                }

                pictureBox1.Invalidate();

            }
        }

        /// <summary>
        /// Check for clicks on the delete button on the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedPanel != null && _selectedPanel.ItemHit == SelectionPartHit.deletebutton)
            {
                RemovePanel(_selectedPanel);
                _selectionPanels.Remove(_selectedPanel);
                pictureBox1.Invalidate();
            }
        }

        #endregion

        #region Property Grid

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        #endregion



        #region tool strip items

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear project?", "Clear Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            pictureBox1.Image = null;
            _selectionPanels.Clear();
            propertyGrid1.SelectedObject = null;
            pictureBox1.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image File";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _imageSourceFolder = Path.GetDirectoryName(openFileDialog.FileName);
                    _selectionPanels = new List<SelectionPanel>();
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Invalidate();
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeAllPanelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            _selectionPanels.Clear();
            pictureBox1.Invalidate();
            propertyGrid1.SelectedObject = null;
        }

        private void exportImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_imageLoaded)
            {
                MessageBox.Show("Must select an image first");
            }
            else if (_selectionPanels.Count == 0)
            {
                MessageBox.Show("Must select image portions");
            }
            else
            {                
                frmExportOptions popupForm = new frmExportOptions();
                popupForm.ImageSourceFolder = _imageSourceFolder;
                if (popupForm.ShowDialog() == DialogResult.OK)
                {
                    ExportImages(popupForm.ImageSourceFolder, popupForm.PanelStartNumber, popupForm.ImageName);
                }
            }
            }
        }

        #endregion



    }
