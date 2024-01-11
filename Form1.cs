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
using ImageSlicer.Utilties;
using System.IO;

namespace Cropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string _ProjectFilter = "SliceSave|*.slicesave";

        /// <summary>
        /// Location of saved panels
        /// </summary>
        string _PanelSavePath;

        ImageSave _currentImage;

        string _imageSourceFolder;

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



        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            Init(false);

        }

        #region Picturebox Events

        /// <summary>
        /// Draw the picture box contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!_currentImage.ImageLoaded) return;

            e.Graphics.DrawImage(_currentImage.Image, new Point(0, 0));


            foreach (ShapeBase s in _currentImage.SectionPanels)
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
            if (!_currentImage.ImageLoaded) return;

            _IsMouseDown = true;
            _mouseDownLocation = new Point(e.X, e.Y);
            _currentImage.SelectedShape = null;
            propertyGrid1.SelectedObject = null;

            if (_currentImage.PanelOver != null)
            {
                _currentImage.SelectedShape = _currentImage.PanelDown = _currentImage.PanelOver;
                _currentImage.PanelPartDown = _currentImage.PanelPartOver;

            }
            else
            {
                _currentImage.SelectedShape = _currentImage.PanelOver = _currentImage.PanelDown = null;
                _currentImage.PanelPartDown = _currentImage.PanelPartDown = SelectionPartHit.none;
                pictureBox1.Invalidate();
            }


            propertyGrid1.SelectedObject = _currentImage.SelectedShape;
            propertyGrid1.Refresh();

        }

        /// <summary>
        /// Drag the selected shape, if there is one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (!_currentImage.ImageLoaded) return;
            if (!_IsMouseDown)
            {

                _currentImage.PanelDown = _currentImage.PanelOver = null;
                _currentImage.PanelPartOver = SelectionPartHit.none;
                foreach (ShapeBase selection in _currentImage.SectionPanels)
                {
                    if (selection.HitTest(e.X, e.Y))
                    {
                        _currentImage.PanelOver = selection;
                        _currentImage.PanelPartOver = selection.ItemHit;
                        break;
                    }
                }

                if (_currentImage.PanelOver == null || _currentImage.PanelPartOver == SelectionPartHit.none)
                {
                    Cursor = Cursors.Default; // Change cursor back to default
                }
                else if (_currentImage.PanelPartOver == SelectionPartHit.body)
                {
                    Cursor = Cursors.SizeAll; // Change cursor when over the Selection rectangle
                }
                else if (_currentImage.PanelPartOver == SelectionPartHit.deletebutton)
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
                if (_currentImage.PanelDown == null) //we're drawing a pane
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

                    switch (_currentImage.PanelPartDown)
                    {
                        case SelectionPartHit.body:
                            _currentImage.PanelDown.Drag(delta.X, delta.Y);
                            break;

                        default:
                            _currentImage.PanelDown.MoveHandle(delta.X, delta.Y);
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
            if (!_currentImage.ImageLoaded) return;

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
            if (!_currentImage.ImageLoaded) return;

            if (_currentImage.SelectedShape != null && _currentImage.SelectedShape is ShapePolygon)
            {
                if (_currentImage.SelectedShape.ItemHit == SelectionPartHit.dragHandle)
                {
                    (_currentImage.SelectedShape as ShapePolygon).DeleteHandle();
                }
                this.Invalidate();
            }
            else
            {
                AddPanel(e.X, e.Y, (int)selectionWidth.Value, (int)selectionHeight.Value);
            }
        }



        #endregion

        private void SetImage()
        {
            pictureBox1.Width = _currentImage.Image.Width;
            pictureBox1.Height = _currentImage.Image.Height;
            pictureBox1.Invalidate();
        }

        #region treeview code


        private void PopulateTree()
        {
            foreach (var panel in _currentImage.SectionPanels.OrderBy(p => p.Order))
            {
                AddPanelToTree(panel);
            }
        }

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
                _currentImage.SelectedShape = _currentImage.PanelDown = _currentImage.PanelOver = _currentImage.SectionPanels.First(p => p.ID.ToString() == n.Name);
                _currentImage.SelectedShape.ItemHit = SelectionPartHit.body;
                _currentImage.PanelPartDown = _currentImage.PanelPartOver = SelectionPartHit.body;
                propertyGrid1.SelectedObject = _currentImage.SelectedShape;

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
            if (_currentImage.SelectedShape != null && _currentImage.SelectedShape.ItemHit == SelectionPartHit.deletebutton)
            {
                RemovePanel(_currentImage.SelectedShape);
                _currentImage.SectionPanels.Remove(_currentImage.SelectedShape);

            }
            else if (_currentImage.SelectedShape != null && _currentImage.SelectedShape is ShapePolygon)
            {
                if (_currentImage.SelectedShape.ItemHit == SelectionPartHit.line)
                {
                    (_currentImage.SelectedShape as ShapePolygon).AddHandle(e.X, e.Y);
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


            _currentImage.AddPanel(panel);
            AddPanelToTree(panel);
            propertyGrid1.SelectedObject = panel;
            pictureBox1.Invalidate();

        }

        /// <summary>
        /// Export the images based on the selectionPanels
        /// </summary>
        /// <param name="outputDirectory"></param>
        public void ExportImages(string outputDirectory, int pStartNumber, string pImageName)
        {
            var sourceImage = _currentImage.Image;
            foreach (ShapeBase selection in _currentImage.SectionPanels)
            {
                // Save the cropped image to a file
                string outputFilePath = Path.Combine(outputDirectory, $"{pImageName}_{selection.Order + pStartNumber}.png");

                if (selection is ShapeRectangle || selection is ShapePolygon)
                {
                    ImageExtractor.ExtractAreaUnderPolygon(sourceImage, (selection as ShapePolygonBase).Points.ToArray(), outputFilePath);
                }
            }

            MessageBox.Show($"Exported {_currentImage.SectionPanels.Count} panels to {outputDirectory}");
        }


        #region Property Grid

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        #endregion

        /// <summary>
        /// Reset the form
        /// </summary>
        private void Init(bool pEnableSave)
        {
            _currentImage = new ImageSave();
            propertyGrid1.SelectedObject = null;
            pictureBox1.Invalidate();
            treeView1.Nodes.Clear();
            _PanelSavePath = null;
            _mouseDownLocation = Point.Empty;
            _SelectionRectangle = Rectangle.Empty;
            saveAsToolStripMenuItem.Enabled = pEnableSave;
            saveToolStripMenuItem.Enabled = pEnableSave;
        }


        #region tool strip items

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_currentImage.Image != null && MessageBox.Show("Clear project?", "Clear Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Init(false);

            importImageToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Open a save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init(true);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                ofd.Title = "Open Saved Panels";
                ofd.Filter = _ProjectFilter;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImage = PanelUtilities.LoadPanels(ofd.FileName);
                    _PanelSavePath = ofd.FileName;
                    _imageSourceFolder = Path.GetDirectoryName(ofd.FileName);
                    PopulateTree();
                    SetImage();
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_PanelSavePath == null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    saveFileDialog.Title = "Select Project";
                    saveFileDialog.Filter = _ProjectFilter;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _PanelSavePath = saveFileDialog.FileName;
                        PanelUtilities.SavePanels(_currentImage, _PanelSavePath);
                    }
                }
            }
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                saveFileDialog.Title = "Save Project as";
                saveFileDialog.Filter = _ProjectFilter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PanelUtilities.SavePanels(_currentImage, saveFileDialog.FileName);
                }

            }
        }



        private void exportImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_currentImage.ImageLoaded)
            {
                MessageBox.Show("Must select an image first");
            }
            else if (_currentImage.SectionPanels.Count == 0)
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
            _currentImage.SectionPanels.Clear();
            pictureBox1.Invalidate();
            propertyGrid1.SelectedObject = null;
        }

        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentImage == null)
                return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image File";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Init(true);

                    _currentImage.Image = new Bitmap(openFileDialog.FileName);
                    SetImage();
                }
            }
        }



        private void generatePanelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_currentImage.ImageLoaded)
            {
                MessageBox.Show("Must select an image first");
            }
            else
            {
                AutoGeneratePanels auto = new AutoGeneratePanels();

                if (auto.ShowDialog() == DialogResult.OK)
                {
                    int padHorizontal = auto.PadHor;
                    int padVertical = auto.PadVert;
                    int rows = auto.NumRows;
                    int cols = auto.NumCols;
                    int order = _currentImage.SectionPanels.Count;

                    PanelUtilities.GeneratePanels(_currentImage.Image, rows, cols, order, padVertical, padHorizontal);
                    pictureBox1.Invalidate();

                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    #endregion



}
