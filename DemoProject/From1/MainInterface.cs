using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Media.Effects;



namespace ImageEditor
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }
        Image Im;
        Boolean open = false;
        static Image ButtonImage;
        Image[] arrayImage=new Image[50000];
        int counter=0;
        bool mirrorFlag = false;
        
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        static Image loadImage;
        public void AllPanelHide()
        {
            BorderRoundPanel.Visible = false;
            BorderNaturePanel.Visible = false;
            BorderDefaultPanel.Visible = false;
            BorderPanel.Visible = false;
            RefinePanel.Visible = false;
            FastPanel.Visible = false;
            BorderFilmPanel.Visible = false;
            BorderPatternPanel.Visible = false;
            BorderInkPanel.Visible = false;
            BorderRippedPaperPanel.Visible = false;
            OverlayPanel.Visible = false;
            OverlayDeafultPanel.Visible = false;
            OverlayBeepPanel.Visible = false;
            OverlayBubblePanel.Visible = false;
            OverlayBurnPanel.Visible = false;
            OverlayColourPanel.Visible = false;
            OverlayLeakPanel.Visible = false;
            OverlayMetalPanel.Visible = false;
            OverlayStreetPanel.Visible = false;
            TrackOpacity.Visible = false;
            resizeHeghtTextBox.Visible = false;
            resizeHeightLabel.Visible = false;
            resizeWidthLabel.Visible = false;
            resizeWidthTextBox.Visible = false;
            resizeButtonResizeNowButton.Visible = false;
            heightTrackBar.Visible = false;
            widthTrackBar.Visible = false;
            ConfirmButton.Visible = false;
            CancelButton.Visible = false;
            RotatePanel.Visible = false;
            contrastTracker.Visible = false;
            brightTracker.Visible = false;
            zoomTracker.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            TextLabel.Visible = false;
            textBox1.Visible = false;
            Color.Visible = false;
            Font.Visible = false;
            AddTextButton.Visible = false;
            StickerLabel.Visible = false;
            addStickerButton.Visible = false;
            //BlurTrackBar.Visible = false;


            
        }

        public void OpenImage()
        {
            
            //openFileDialog1.Filter = "FileName|*.png|Jpeg|*.jpg"; i can only open this two type picture.
            openFileDialog1.Title = "Open Image";  //Title of the showdialog
            //openFileDialog1.ShowHelp =true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Im = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = Im;
                open = true;
                counter = 0;
                arrayImage[counter++] = pictureBox1.Image;
                mirrorFlag = false;
            }
        }
        /* This Method used for saving the image from pictureBox1 */
        void SaveImage()
        {
            if (open)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image|*.jpg|Bitmap|*.bpm|Portable network graphics|*.png";
                ImageFormat format = ImageFormat.Png;
                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    if (ext.Equals("jpg"))
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if (ext.Equals("bpm"))
                    {
                        format = ImageFormat.Bmp;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }
                

                
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void RotateImage90()
        {
            if (open)
            {
                Image im = pictureBox1.Image;
                Bitmap im1 = new Bitmap(im);
                im1.RotateFlip(RotateFlipType.Rotate90FlipXY);
                pictureBox1.Image = im1;
                loadImage = im1;
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void RotateImage180X()
        {
            if (open)
            {
                Image im = pictureBox1.Image;
                Bitmap im1 = new Bitmap(im);
                im1.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox1.Image = im1;
                loadImage = im1;
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void RotateImage180Y()
        {
            if (open)
            {
                Image im = pictureBox1.Image;
                Bitmap im1 = new Bitmap(im);
                im1.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox1.Image = im1;
                loadImage = im1;
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void MirrorImage()
        {
            if (open)
            {
                if (mirrorFlag == false)
                {
                    Bitmap bmp1 = (Bitmap)pictureBox1.Image;
                    Bitmap bmp2 = new Bitmap(bmp1.Width * 2, bmp1.Height);

                    Graphics G = Graphics.FromImage(bmp2);

                    G.DrawImage(bmp1, 0, 0);
                    bmp1.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    G.DrawImage(bmp1, bmp1.Width, 0);
                    pictureBox1.Image = bmp2;
                    mirrorFlag = true;
                }
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void reload()
        {
            if (!open)
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                pictureBox1.Image = Im;
                

            }
        }

        public void OverlayImage(Image temp)
        {
            if (!open)
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Image im = pictureBox1.Image;

                Image im1 = temp;


                //string[] a = Directory.GetFiles(@"C:\Users\user\Desktop\C# project\lightoff.jpg");
                Bitmap bim = new Bitmap(im);
                Bitmap bim1 = new Bitmap(im1);

                Graphics g = Graphics.FromImage(bim);

                g.DrawImage(bim1, 0, 0, bim.Size.Width, bim.Size.Height);
                g.Dispose();
                // g.DrawImage(bim1, 0, 0);

                //g.CompositingMode = g.CompositingMode.SourceOver;

                pictureBox1.Image = bim;
            }


        }
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }

        public void OpacityValueChange(Image temp)
        {
            if (open)
            {
                float opacityvalue = (float)TrackOpacity.Value / 10;
                Image tempIm = ChangeOpacity(temp, opacityvalue);
                OverlayImage(tempIm);
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
           
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {

                graphics.CompositingMode = CompositingMode.SourceCopy;                   /*Compositing controls how pixels are blended with the background
                                                                                         * SourceCopy specifies that when a color is rendered, it overwrites the background color.*/
                graphics.CompositingQuality = CompositingQuality.HighQuality;           //graphics.CompositingQuality determines the rendering quality level of layered images.

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;     //graphics.InterpolationMode determines how intermediate values between two endpoints are calculated

                graphics.SmoothingMode = SmoothingMode.HighQuality;                   //graphics.SmoothingMode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing) -- probably only works on vectors.

                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;              // graphics.PixelOffsetMode affects rendering quality when drawing the new image;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        void AutoContrast()
        {
            if (!open)
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float c=2f;
                float t=(1.0f-c)/2.0f;
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{c,0,0,0,0},
                    new float[]{0,c,0,0,0},
                    new float[]{0,0,c,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{t, t, t, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }
       
        void Contrast()
        {
            if (!open)
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float c = Convert.ToSingle( contrastTracker.Value )/ 10.0f;
                float t = (1.0f - c) / 2.0f;
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{c,0,0,0,0},
                    new float[]{0,c,0,0,0},
                    new float[]{0,0,c,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{t, t, t, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

        void Brightness()
        {
            if (!open)
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float c = Convert.ToSingle(brightTracker.Value) / 10.0f;
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{c,0,0,0,0},
                    new float[]{0,c,0,0,0},
                    new float[]{0,0,c,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

        void Zoom(Size size)
        {
            Image img = Im;
            Bitmap bmp = new Bitmap(img, (img.Width * size.Width) / 250, (img.Height * size.Height) / 250);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            pictureBox1.Image = bmp;
        }

        int blurAmount = 3;
        void blur()
        {
            Bitmap newBitmap = new Bitmap(Im);

            // Int32 avgR = 0, avgG = 0, avgB = 0;


            for (int x = blurAmount; x <= newBitmap.Width - blurAmount; x++)
            {
                for (int y = blurAmount; y <= newBitmap.Height - blurAmount; y++)
                {
                    try
                    {
                        Color prevX = newBitmap.GetPixel(x - blurAmount, y);
                        Color nextX = newBitmap.GetPixel(x + blurAmount, y);
                        Color prevY = newBitmap.GetPixel(x, y - blurAmount);
                        Color nextY = newBitmap.GetPixel(x, y + blurAmount);

                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4);

                        newBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(avgR, avgG, avgB));

                    }
                    catch (Exception) { }
                }
            }
            
        }
        /*void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.9f, 0, 0, 0, 0},
            new float[]{0, 1+1.5f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void Frozen()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void RedScale()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                         new float[]{.393f, .349f, .272f, 0, 0},
                         new float[]{.769f, .686f, .534f, 0, 0},
                         new float[]{.189f, .168f, .131f, 0, 0},
                         new float[]{0, 0, 0, 1, 0},
                         new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void grayscale()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{0.299f, 0.299f, 0.299f, 0, 0},
                    new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                    new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void Dramatic()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                     new float[]{.393f, .349f, .272f+1.3f, 0, 0},
            new float[]{.769f, .686f+0.5f, .534f, 0, 0},
            new float[]{.189f+2.3f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }*/
        /*void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }

        }
        void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });

                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

            void flash()
        {
            if (!open)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = Im;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0f, 0, 0, 0},
                    new float[]{0, 0, 1+5f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }


        }*/
        

   
        
       
       //**********************Event Handler Area*********************// 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void openRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FastButtonClick(object sender, EventArgs e)
        {
            AllPanelHide();
            FastPanel.Visible = true;
          
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RefineButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            RefinePanel.Visible = true;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void FastCrop_Click(object sender, EventArgs e)
        {

        }

        private void BorderNaturePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BorderButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderPanel.Visible = true;
            //TrackOpacity.Visible = true;
            

        }

        private void BorderDefaultButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderDefaultPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
            
           
            
        }

        private void BorderNatureButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderNaturePanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
            
           

        }

        private void BorderRoundButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderRoundPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
          
            
        }
       

        private void BorderFilmButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderFilmPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void BorderPatternButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderPatternPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void BorderInkButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderInkPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void BorderRippedPaperButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            BorderRippedPaperPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayBurnPanel_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayBurnPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayPanel.Visible = true;
        }

        private void OverlayDefaultButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayDeafultPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayBeepButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayBeepPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayBubbleButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayBubblePanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayColourButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayColourPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayLeakButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayLeakPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayMetalButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayMetalPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;
        }

        private void OverlayStreetButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            OverlayStreetPanel.Visible = true;
            TrackOpacity.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
            mainPanel.Visible = false;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You want to Exit", "Close", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
            else
            {
            }
        }

        private void OverlayColourPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You want to Exit", "Close", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.Exit(); 
            }
            else if (result == DialogResult.No)
            {
                e.Cancel=true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void MainInterface_Click(object sender, EventArgs e)
        {
            
        }

        private void FastRotateButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            mainPanel.Visible = false;
            RotatePanel.Visible = true;
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
            

        }


        private void FastMirrorButton_Click(object sender, EventArgs e)
        {
            MirrorImage();
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OverlayDeafultBeepButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayDeafultBeepButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
            
            
        }

        private void OverlayDefaultBubbleButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayDefaultBubbleButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderDefaultHeartButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultHeartButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
            
        
        }
        private void TrackOpacity_Scroll(object sender, EventArgs e)
        {
            reload();
            OpacityValueChange(ButtonImage);
        }

        private void OverlayDefaultFadeButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayDefaultFadeButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tempCounter = counter;
            if (tempCounter>0)
            {
                pictureBox1.Image = arrayImage[--tempCounter];
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tempCounter=counter;
            if (tempCounter<=counter)
            {
                pictureBox1.Image = arrayImage[tempCounter++];
            }
        }

        private void OverlayDefaultRedblueButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayDefaultRedblueButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBeep2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBeep2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayBeepGreenButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBeepGreenButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayBeepBlackishButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBeepBlackishButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayBeepFadeButton_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBeepFadeButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBubbleDesign1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBubbleDesign1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBubbleDesign2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBubbleDesign2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBubbleDesign3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBubbleDesign3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBubbleDesign4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBubbleDesign4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBubbleDesign44Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBubbleDesign44Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBurn1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBurn1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayBurn2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBurn2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBurn3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBurn3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayBurn4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBurn4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayBurn5Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayBurn5Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayMetal1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayMetal1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayMetal2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayMetal2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayMetal3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayMetal3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayMetal4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayMetal4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayMetal5Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayMetal5Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayColour1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayColour1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayColour2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayColour2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayColour3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayColour3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayColour4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayColour4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        

        private void OverlayLeak1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayLeak2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void OverlayLeak3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayLeak4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayLeak5Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak5Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayLeak6Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayLeak6Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderDefaultBlackButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultBlackButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderDefaultCurtainButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultCurtainButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;

        }

        private void BorderDefaultDesignFrameButton1_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultDesignFrameButton1.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderDefaultDesignFrame2_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultDesignFrame2.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderDefaultMarkerButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderDefaultMarkerButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmBulkButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmBulkButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmDarkButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmDarkButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmDimButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmDimButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmSimpleButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmSimpleButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmTidyButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmTidyButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderFilmLargeButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderFilmLargeButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRoundDesign1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRoundDesign1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRoundDesign2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRoundDesign2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRoundDesign3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRoundDesign3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRoundDesign4Button_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRoundDesign4Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRoundDesign5Button_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRoundDesign5Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRippedPaperartonButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRippedPaperartonButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRippedPaperElvaButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRippedPaperElvaButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRippedPaperEnButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRippedPaperEnButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
            
        }

        private void BorderRippedPaperFemButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRippedPaperFemButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderRippedPaperFemtonButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderRippedPaperFemtonButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayStreet1Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayStreet1Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayStreet2Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayStreet2Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void OverlayStreet3Button_Click(object sender, EventArgs e)
        {
            ButtonImage = OverlayStreet3Button.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderPatternLightButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderPatternLightButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderPatternDesignButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderPatternDesignButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderPatternStripButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderPatternStripButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderPatternDimButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderPatternDimButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderPatternBlueButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderPatternBlueButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureAutumnButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureAutumnButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureButterflyButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureButterflyButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureCapucineButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureCapucineButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureColorNatureButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureColorNatureButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureMargaretButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureMargaretButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderNatureLeafButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderNatureLeafButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

   



   

        private void BorderInkBlackOneButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderInkBlackOneButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderInkBlacksvnButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderInkBlacksvnButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderInkColourithButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderInkColourithButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderInkColorivnButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderInkColorivnButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

        private void BorderInkColourthhButton_Click(object sender, EventArgs e)
        {
            ButtonImage = BorderInkColourthhButton.BackgroundImage;
            reload();
            OpacityValueChange(ButtonImage);
            arrayImage[counter++] = pictureBox1.Image;
        }

       

        private void FastResizeButton_Click(object sender, EventArgs e)
        {
            resizeHeghtTextBox.Visible = true;
            resizeHeightLabel.Visible = true;
            resizeWidthLabel.Visible = true;
            resizeWidthTextBox.Visible = true;
            resizeButtonResizeNowButton.Visible = true;
            heightTrackBar.Visible = true;
            widthTrackBar.Visible = true;
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
            FastPanel.Visible = false;
            mainPanel.Visible = false;
            resizeHeghtTextBox.Text =Convert.ToString(pictureBox1.Image.Height);
            resizeWidthTextBox.Text =Convert.ToString(pictureBox1.Image.Width); 

        }

        private void widthTrackBar_Scroll(object sender, EventArgs e)
        {
            int width;
            width = (Convert.ToInt32(pictureBox1.Image.Width) * widthTrackBar.Value) / 10;
            pictureBox1.Image = ResizeImage(pictureBox1.Image, width, Convert.ToInt32(pictureBox1.Image.Height));
            resizeHeghtTextBox.Text = Convert.ToString(pictureBox1.Image.Height);
            resizeWidthTextBox.Text = Convert.ToString(pictureBox1.Image.Width); 
        }

       


        private void resizeButtonResizeNowButton_Click(object sender, EventArgs e)
        {
            if (resizeHeghtTextBox.Text.Equals("") && resizeWidthTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please Insert Height and width");
            }
            else
            {
                pictureBox1.Image=ResizeImage(pictureBox1.Image,Convert.ToInt32(resizeWidthTextBox.Text),Convert.ToInt32(resizeHeghtTextBox.Text));
            }

        }

        private void heightTrackBar_Scroll(object sender, EventArgs e)
        {
            int height;
            height = (Convert.ToInt32(pictureBox1.Image.Height) * heightTrackBar.Value) / 10;
            pictureBox1.Image = ResizeImage(pictureBox1.Image, Convert.ToInt32(pictureBox1.Image.Width), height);
            resizeHeghtTextBox.Text = Convert.ToString(pictureBox1.Image.Height);
            resizeWidthTextBox.Text = Convert.ToString(pictureBox1.Image.Width); 
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm Changes", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Im = pictureBox1.Image;
                mainPanel.Visible = true;
                AllPanelHide();
            }
            else
            {
                pictureBox1.Image = Im;
                mainPanel.Visible = true;
                AllPanelHide();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit without changing?", "Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                pictureBox1.Image = Im;
                mainPanel.Visible = true;
                AllPanelHide();
            }
            else
            {
                
            }
        }

       

       

        private void RotateButton90_Click(object sender, EventArgs e)
        {
            RotateImage90();
        }

        private void RotateButtonLeft_Click(object sender, EventArgs e)
        {
            RotateImage180Y();
        }

        private void RotateButtonTopBottom_Click(object sender, EventArgs e)
        {
            RotateImage180X();
        }

        private void EffectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void FastAutoContrastButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            AutoContrast();
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
        }

        private void RefineContrastButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            mainPanel.Visible=false;
            contrastTracker.Visible = true;
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
            Contrast();

        }

        private void contrastTracker_Scroll(object sender, EventArgs e)
        {

            Contrast();
        }

        private void FastBrightness_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            mainPanel.Visible = false;
            brightTracker.Visible = true;
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
            Brightness();

        }

        private void brightTracker_Scroll(object sender, EventArgs e)
        {
            Brightness();
        }

        private void FastZoomButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            mainPanel.Visible=false;
            zoomTracker.Visible = true;
            CancelButton.Visible = true;
            ConfirmButton.Visible = true;
        }

        private void zoomTracker_Scroll(object sender, EventArgs e)
        {
            Zoom(new Size(zoomTracker.Value,zoomTracker.Value));
        }

        private void RefineBlurButton_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            ConfirmButton.Visible = true;
            CancelButton.Visible = true;
            mainPanel.Visible = false;
            //BlurTrackBar.Visible = true;
            blur();
            


        }

        
        private bool Dragging;
        private int xPos;
        private int yPos;
        int picX, picY;
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }


        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {

            Control c = sender as Control;
            if (Dragging && c != null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;
                picX = c.Top;
                picY = c.Left;
            }
            
        }
        private Point MouseDownLocation;
        

        private void TextButton_Click(object sender, EventArgs e)
        {
            if (open)
            {
                AllPanelHide();
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                TextLabel.Visible = false;
                textBox1.Visible = true;
                Color.Visible = true;
                Font.Visible = true;
                AddTextButton.Visible = true;
                CancelButton.Visible = true;
                ConfirmButton.Visible = true;
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox1.Left = e.X + textBox1.Left - MouseDownLocation.X;
                textBox1.Top = e.Y + textBox1.Top - MouseDownLocation.Y;

            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textBox1.Visible = false;
                Color.Visible = false;
                Font.Visible = false;
                TextLabel.Visible = true;
                TextLabel.Top = textBox1.Top;
                TextLabel.Left = textBox1.Left;
                TextLabel.Text = textBox1.Text;
                TextLabel.ForeColor = textBox1.ForeColor;
                TextLabel.Font = textBox1.Font;

            }
        }


        public void AddTextOnImage()
        {
            
            Bitmap b = new Bitmap(Im);
            /*MessageBox.Show(" " +pictureBox1.Height+" " + pictureBox1.Width);
            MessageBox.Show(" " + b.Height + "  " + b.Width);*/
            int wr = (b.Width / pictureBox1.Width);
            int hr = (b.Height / pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                Font f = new Font(fontDialog1.Font, FontStyle.Regular);
                Rectangle ad = new Rectangle(TextLabel.Left*wr-picY, TextLabel.Top*hr-picX, TextLabel.Width * wr, TextLabel.Height * hr);
                SolidBrush ac = new SolidBrush(TextLabel.ForeColor);
                Point ab = new Point(TextLabel.Top, TextLabel.Left);
                g.DrawString(TextLabel.Text, f, ac, ad);
            }
            pictureBox1.Image = b;
            /*MessageBox.Show(" "+FinalLabelText.Top+ FinalLabelText.Left);
            MessageBox.Show(Convert.ToString(f));*/
        }

        private void Font_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void AddTextButton_Click(object sender, EventArgs e)
        {
            AddTextOnImage();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextLabel_Click_1(object sender, EventArgs e)
        {
            TextLabel.Visible = false;
            textBox1.Visible = true;
            Color.Visible = true;
            Font.Visible = true;
            textBox1.Top = TextLabel.Top;
            textBox1.Left = TextLabel.Left;
            textBox1.Text = TextLabel.Text;
            textBox1.ForeColor = TextLabel.ForeColor;
            textBox1.Font = TextLabel.Font;

        }

        private void StickersButton_Click(object sender, EventArgs e)
        {
            if (open)
            {
                AllPanelHide();
                StickerLabel.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                Image image = Properties.Resources.stickertest;
                StickerLabel.Width = image.Width;
                StickerLabel.Height = image.Height;
                StickerLabel.Image = image;
                addStickerButton.Visible = true;
                CancelButton.Visible = true;
                ConfirmButton.Visible = true;
            }
            else
            {
                MessageBox.Show("At first Open An Image", "File not Opened ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StickerLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void StickerLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StickerLabel.Left = e.X + StickerLabel.Left - MouseDownLocation.X;
                StickerLabel.Top = e.Y + StickerLabel.Top - MouseDownLocation.Y;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addsticker();
        }
        void Addsticker()
        {
            Bitmap b = new Bitmap(Im);
            //Bitmap c = new Bitmap(StickerLabel.Image);
            int wr = (b.Width / pictureBox1.Width);
            int hr = (b.Height / pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                Font f = new Font(fontDialog1.Font, FontStyle.Regular);
                Rectangle ad = new Rectangle(StickerLabel.Left * wr - picY, StickerLabel.Top * hr - picX, StickerLabel.Width * wr, StickerLabel.Height * hr);
               // g.DrawString(TextLabel.Text, f, ac, ad);
                g.DrawImage(StickerLabel.Image, ad);
            }
            pictureBox1.Image = b;

        }
        static float zoomInFactor = 1;


        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open)
            {
                CancelButton.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                zoomInFactor = zoomInFactor + .1f;
                if (zoomInFactor > 0)
                {
                    
                    Image img = Im;
                    Bitmap bmp = new Bitmap(img, Convert.ToInt32((img.Width * zoomInFactor)), Convert.ToInt32((img.Height * zoomInFactor)));
                    Graphics g = Graphics.FromImage(bmp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void BlurTrackBar_Scroll(object sender, EventArgs e)
        {
            //blurAmount = BlurTrackBar.Value;
            blur();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open)
            {
                CancelButton.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                zoomInFactor = zoomInFactor - .1f;
                if (zoomInFactor > 0)
                {
                    
                    Image img = Im;
                    Bitmap bmp = new Bitmap(img, Convert.ToInt32((img.Width * zoomInFactor)), Convert.ToInt32((img.Height * zoomInFactor)));
                    Graphics g = Graphics.FromImage(bmp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    pictureBox1.Image = bmp;
                }
            }

        }

        private void zoomToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllPanelHide();
            pictureBox1.Image = Im;
        }

     
        
    }
}
