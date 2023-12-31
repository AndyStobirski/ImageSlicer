using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Cropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Selection> _selections;


        //
        //  Mouse Mouse
        //
        Selection _SelectedSelection;
        bool _mouseDown;
        Point _dragOffset;  //when mouse down occurs, record it's position relative to the shape origin
        SelectionPartHit _SelectionItemOver;

        private bool _imageLoaded => pictureBox1.Image != null;


        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = new Bitmap(@"C:\Users\andy\Pictures\Scans\Big Vern\44\Scan_20231230.png");
            _selections = new List<Selection>();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Load an image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Draw the picture box contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!_imageLoaded) return;

            foreach (Selection s in _selections)
            {
                s.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            _selections.Clear();
            propertyGrid1.SelectedObject = null;
        }

        /// <summary>
        /// Check for collision with a shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;

            if (_SelectedSelection != null)
            {
                _dragOffset = new Point(e.X - _SelectedSelection.Location.X, e.Y - _SelectedSelection.Location.Y);
                propertyGrid1.SelectedObject = _SelectedSelection;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                _selections.ForEach(s => s.Unselect());
                pictureBox1.Invalidate();
            }
        }

        /// <summary>
        /// Drag the selected shape, if there is one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown)
            {
                _SelectedSelection = null;
                foreach (Selection selection in _selections)
                {
                    if (selection.IsHit(e.X, e.Y))
                    {
                        _SelectedSelection = selection;
                        _SelectionItemOver = selection.ItemHit;
                        break;
                    }
                }

                if (_SelectedSelection == null || _SelectionItemOver == SelectionPartHit.none)
                {
                    Cursor = Cursors.Default; // Change cursor back to default
                }
                else if (_SelectionItemOver == SelectionPartHit.body)
                {
                    Cursor = Cursors.Cross; // Change cursor when over the Selection rectangle
                }
                else
                {
                    Cursor = Cursors.SizeAll; // Change cursor when over a handle   
                }

            }
            else
            {
                if (_SelectedSelection == null) return;

                switch (_SelectionItemOver)
                {
                    case SelectionPartHit.body:
                        _SelectedSelection.DragShape(e.X - _dragOffset.X, e.Y - _dragOffset.Y);
                        break;

                    default:
                        _SelectedSelection.DragHandle(e.X, e.Y, _SelectionItemOver);
                        break;

                }

                pictureBox1.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        /// <summary>
        /// Add a selection to the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _selections.Add(new Selection(e.X, e.Y, (int)selectionWidth.Value, (int)selectionHeight.Value));
            _selections.Last().Order = _selections.Count;
            propertyGrid1.SelectedObject = _selections.Last();
            pictureBox1.Invalidate();
        }

        public void ExportImages(string outputDirectory)
        {
            var sourceImage = pictureBox1.Image;

            foreach (Selection selection in _selections)
            {
                using (Bitmap croppedImage = new Bitmap(selection.Dimensions.Width, selection.Dimensions.Height))
                {
                    using (Graphics g = Graphics.FromImage(croppedImage))
                    {
                        // Draw the portion of the image within the rectangle onto the new bitmap
                        g.DrawImage(sourceImage, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height),
                            selection.Bounds, GraphicsUnit.Pixel);
                    }

                    // Save the cropped image to a file
                    string outputFilePath = Path.Combine(outputDirectory, $"{txtOutputName.Text}_{selection.Order}.png");
                    croppedImage.Save(outputFilePath, ImageFormat.Png);
                }
            }
        }

        private void toolStripExportImage_Click(object sender, EventArgs e)
        {

        }

        private void llLoadImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image File";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selections = new List<Selection>();
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Invalidate();
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void llExportSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_imageLoaded)
            {
                MessageBox.Show("Must select an image first");
            }
            else if (_selections.Count == 0)
            {
                MessageBox.Show("Must select image portions");
            }
            else if (txtOutputName.Text.Trim() == "")
            {
                MessageBox.Show("Must select an output name");
                txtOutputName.Focus();
            }
            else
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    folderBrowserDialog.Description = "Select a folder";

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportImages(folderBrowserDialog.SelectedPath);
                    }
                }
            }
        }

        private void llClearSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _selections.Clear();
            pictureBox1.Invalidate();
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = null;
            _selections.Clear();
            propertyGrid1.SelectedObject = null;
        }

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
            int order = 0;

            int cellWidth = (imageWidth - (padHorizontal * (cols - 1))) / cols;
            int cellHeight = (imageHeight - (padVertical * (rows - 1))) / rows;

            
                for (int c = 0; c < cols; c++)
                {
                for (int r = 0; r < rows; r++)
                {
                    order++;

                    int x = c * (cellWidth + padHorizontal);
                    int y = r * (cellHeight + padVertical);

                    int x2 = x + cellWidth;
                    int y2 = y + cellHeight;

                    Console.WriteLine($"Cell [{r},{c}]: ({x},{y}) - ({x2},{y2})");

                    _selections.Add(

                            new Selection(x, y, x2, y2) { Order = order}

                        );

                }

                pictureBox1.Invalidate();

            }

            //    Size size = new Size
            //        (
            //            (pictureBox1.Size.Width / (int)numRows.Value) - ((int)numRows.Value * (int)padH.Value)
            //            , (pictureBox1.Size.Height / (int)numCols.Value) - ((int)numRows.Value * (int)padV.Value)
            //        );

            //    for (int row = 0; row < (int)numRows.Value; row++)
            //    {
            //        for (int col = 0; col < (int)numRows.Value; col++)
            //        {
            //            _selections.Add(

            //                    new Selection(
            //                        (row * size.Width) + ((int)padH.Value * (row + 1))
            //                        , (col * size.Height) + ((int)padV.Value * (col + 1))
            //                        , size.Width
            //                        , size.Height
            //                        )

            //                );
            //        }
            //    }

            //    pictureBox1.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void llDeleteSelectedPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_SelectedSelection != null)
            {
                _selections.Remove(_SelectedSelection);
                pictureBox1.Invalidate ();
            }
        }
    }
}