using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlicer
{
    public class ImageSave
    {
        public ImageSave() {
            SectionPanels = [];
            Clean = true;
        }

        public bool Clean {  get; set; }

        /// <summary>
        /// Panel hit detection
        /// </summary>
        public ShapeBase PanelDown { get; set; }
        public SelectionPartHit PanelPartDown { get; set; }
        public ShapeBase PanelOver { get; set; }
        public SelectionPartHit PanelPartOver { get; set; }

        public bool ImageLoaded => _imageString != null;

        public void AddPanel(ShapeBase pAdd)
        {
            pAdd.Order = SectionPanels.Count;
            SectionPanels.Add(pAdd);
            Clean = false;
        }

        public void RemovePanel(ShapeBase pRemoved)
        {
            SectionPanels.Remove(pRemoved);
            Clean = false;
        }

        public void RemoveAllPanels()
        {
            SectionPanels = [];
            Clean = false;
        }

        public void SetPanels(List<ShapeBase> pPanels)
        {
            SectionPanels = pPanels;
        }

        /// <summary>
        /// Panels added to the image
        /// </summary>
        public List<ShapeBase> SectionPanels { get; private set; }


        ShapeBase _SelectedShape;
        public ShapeBase SelectedShape
        {
            get { return _SelectedShape; }
            set
            {

                foreach (var p in SectionPanels)
                {
                    p.Selected = p == value;
                }

                _SelectedShape = value;
            }
        }



        /// <summary>
        /// Access the loaded image
        /// </summary>
        #region image

        [JsonProperty("_imageString")]
        private string _imageString;

        [JsonIgnore]
        private Bitmap _image;

        [JsonIgnore]
        public Bitmap Image
        {
            get
            {
                if (_image == null && _imageString != null) {
                    // Convert Base64 string to byte array
                    byte[] imageBytes = Convert.FromBase64String(_imageString);

                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                        _image = (Bitmap)Bitmap.FromStream(stream);
                    }
                }
                return _image;

            }
            set 
            {
                byte[] imageBytes;
                using (MemoryStream stream = new MemoryStream())
                {
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Png); 
                    imageBytes = stream.ToArray();
                }
                _imageString = Convert.ToBase64String(imageBytes);
            }
        }

        #endregion
    }
}
