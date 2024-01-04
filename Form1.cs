using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Diagnostics;
using System.Runtime.Serialization;
using ImageSlicer;
using ImageSlicer.ImageExractors;

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
        List<ShapeBase> _selectionPanels;

        /// <summary>
        /// Panel hit detection
        /// </summary>
        ShapeBase _panelDown;
        SelectionPartHit _panelPartDown;
        ShapeBase _panelOver;
        SelectionPartHit _panelPartOver;



        ShapeBase _SelectedShape;
        public ShapeBase SelectedShape
        {
            get { return _SelectedShape; }
            set
            {

                foreach (var p in _selectionPanels)
                {
                    p.Selected = p == value;
                }

                _SelectedShape = value;
            }
        }


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
            //_selectionPanels = new List<ShapeBase>();
            // pictureBox1.Invalidate();
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

            foreach (ShapeBase s in _selectionPanels)
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
            SelectedShape = null;
            propertyGrid1.SelectedObject = null;

            if (_panelOver != null)
            {
                SelectedShape = _panelDown = _panelOver;
                _panelPartDown = _panelPartOver;

            }
            else
            {
                SelectedShape = _panelOver = _panelDown = null;
                _panelPartDown = _panelPartDown = SelectionPartHit.none;
                pictureBox1.Invalidate();
            }


            propertyGrid1.SelectedObject = SelectedShape;
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
                foreach (ShapeBase selection in _selectionPanels)
                {
                    if (selection.HitTest(e.X, e.Y))
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

                    Point delta = new Point(e.X - _mouseDownLocation.X, e.Y - _mouseDownLocation.Y);

                    switch (_panelPartDown)
                    {
                        case SelectionPartHit.body:
                            _panelDown.Drag(delta.X, delta.Y);
                            break;

                        default:
                            _panelDown.MoveHandle(delta.X, delta.Y);
                            break;

                    }

                    _mouseDownLocation = new Point(e.X, e.Y);
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

            if (SelectedShape != null && SelectedShape is ShapePolygon)
            {
                if (SelectedShape.ItemHit == SelectionPartHit.dragHandle)
                {
                    (SelectedShape as ShapePolygon).DeleteHandle();
                }
                this.Invalidate();
            }
            else
            {
                AddPanel(e.X, e.Y, (int)selectionWidth.Value, (int)selectionHeight.Value);
            }
        }



        #endregion

        #region treeview code

        /// <summary>
        /// Add a panel into the treeview
        /// </summary>
        /// <param name="pNewPanel"></param>
        public void AddPanelToTree(ShapeBase pNewPanel)
        {
            treeView1.Nodes.Add(pNewPanel.ID.ToString(), pNewPanel.Name);
        }

        /// <summary>
        /// Remove the specified panel from the treeview
        /// </summary>
        /// <param name="pPanel"></param>
        public void RemovePanel(ShapeBase pPanel)
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
                SelectedShape = _panelDown = _panelOver = _selectionPanels.First(p => p.ID.ToString() == n.Name);
                SelectedShape.ItemHit = SelectionPartHit.body;
                _panelPartDown = _panelPartOver = SelectionPartHit.body;
                propertyGrid1.SelectedObject = SelectedShape;

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
            if (SelectedShape != null && SelectedShape.ItemHit == SelectionPartHit.deletebutton)
            {
                RemovePanel(SelectedShape);
                _selectionPanels.Remove(SelectedShape);

            }
            else if (SelectedShape != null && SelectedShape is ShapePolygon)
            {
                if (SelectedShape.ItemHit == SelectionPartHit.line)
                {
                    (SelectedShape as ShapePolygon).AddHandle(e.X, e.Y);
                }
            }
            pictureBox1.Invalidate();
        }

        #endregion

        private ShapeBase ShapeToAdd(int pX, int pY, int pWidth, int pHeight)
        {

            if (circleToolStripMenuItem.Checked)
            {
                return new ShapeCircle(pX, pY);
            }
            else if (rectangleToolStripMenuItem.Checked)
            {
                return new ShapeRectangle(pX, pY, pWidth, pHeight);
            }
            else
                return new ShapePolygon(pX, pY);
        }

        /// <summary>
        /// Add a panel onto the form
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void AddPanel(int x, int y, int w, int h)
        {
            var panel = ShapeToAdd(x, y, w, h);
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
            foreach (ShapeBase selection in _selectionPanels)
            {
                // Save the cropped image to a file
                string outputFilePath = Path.Combine(outputDirectory, $"{pImageName}_{selection.Order + pStartNumber}.png");

                if (selection is ShapeRectangle || selection is ShapePolygon)
                {
                    ImageExtractor.ExtractAreaUnderPolygon(sourceImage, (selection as ShapePolygonBase).Points.ToArray(), outputFilePath);
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

                            new ShapeRectangle(x, y, panelWidth, panelHeight) { Order = order }

                        );

                    order++;

                    _selectionPanels.Last().Selected = false;

                }

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
            treeView1.Nodes.Clear();
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
                    treeView1.Nodes.Clear();
                    _imageSourceFolder = Path.GetDirectoryName(openFileDialog.FileName);
                    _selectionPanels = new List<ShapeBase>();
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

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            polygonToolStripMenuItem.Checked = true;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = true;
            polygonToolStripMenuItem.Checked = false;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            polygonToolStripMenuItem.Checked = false;

        }

        private void removeAllPanelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            _selectionPanels.Clear();
            pictureBox1.Invalidate();
            propertyGrid1.SelectedObject = null;
        }
    }

    #endregion



}
