using System;
using System.Drawing;
using System.Windows.Forms;
using Pdftools.Pdf;
using Pdftools.Pdf2Img;
using Pdftools.PdfSplMrg;
using PdfMergeSplit.Properties;

namespace PdfMergeSplit
{
    public partial class PdfMergeSplitForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new PdfMergeSplitForm());
        }
        public PdfMergeSplitForm()
        {
            InitializeComponent();
        }

        /********************************************************************/

        private static Color g_colorBlue     = Color.FromArgb(  0, 102, 153);
        private static Color g_colorGray     = Color.FromArgb(200, 200, 200);
        private static Color g_colorDarkGray = Color.FromArgb(160, 160, 160);

        private const int g_frameHeight = 100;
        private const int g_frameRightOffset = 20;
        private int g_inputFormCount   = 0;
        private int g_inputFormNumber  = 1;
        private int g_outputFormCount  = 0;
        private int g_outputFormNumber = 1;

        private void PdfMergeSplitForm_Load(object sender, EventArgs e)
        {
            comboBoxPageLimit.SelectedIndex = 0;
            ButtonNewOutput_Click(null, null);
        }
        private void ButtonNewInput_Click(object sender, EventArgs e)
        {
            InputFrame inputFrame = new InputFrame(panelInput.Width - g_frameRightOffset,
                                                   g_frameHeight,
                                                   g_inputFormNumber);
            inputFrame.Location = new Point(0, g_frameHeight * g_inputFormCount);            
            g_inputFormCount++;
            g_inputFormNumber++;

            if (inputFrame.Open(GetPageLimit()))
                this.panelInput.Controls.Add(inputFrame);
            else
            {
                g_inputFormCount--;
                inputFrame.Dispose();
            }
        }
        private void ButtonNewOutput_Click(object sender, EventArgs e)
        {
            OutputFrame outputFrame = new OutputFrame(panelOutput.Width - g_frameRightOffset,
                                                      g_frameHeight,
                                                      g_outputFormNumber);
            outputFrame.Location = new Point(0, g_frameHeight * g_outputFormCount);
            this.panelOutput.Controls.Add(outputFrame);

            g_outputFormCount++;
            g_outputFormNumber++;
        }
        private InDoc GetInput(int instance)
        {
            foreach (InputFrame inputFrame in panelInput.Controls)
            {
                if (inputFrame.GetInstance() == instance)
                    return inputFrame.GetInput();
            }
            return null;
        }
        private int GetPageLimit()
        {
            int defaultPageLimit = 10;
            try
            {
                return int.Parse(comboBoxPageLimit.SelectedItem.ToString());
            }
            catch
            {
                return defaultPageLimit;
            }
        }
        private void RemoveInputFrame(InputFrame inputFrame, bool hideOnly)
        {            
            if (hideOnly)
                /* This is not a real remove function. Instead the form is
                 * just hidden. As a result the form is still accessible and
                 * pages that are refered to in Output documents are still valid.
                 */
                inputFrame.Size = new Size(0, 0);
            else
                panelInput.Controls.Remove(inputFrame);
            int frameNumber = inputFrame.GetInstance();
            foreach (Frame frame in panelInput.Controls)
                if (frame.GetInstance() > frameNumber)
                    frame.Top -= g_frameHeight;
            g_inputFormCount--;
        }
        private void RemoveOutputFrame(OutputFrame outputFrame)
        {
            int frameNumber = outputFrame.GetInstance();
            panelOutput.Controls.Remove(outputFrame);

            foreach (Frame frame in panelOutput.Controls)
                if (frame.GetInstance() > frameNumber)
                    frame.Top -= g_frameHeight;
            g_outputFormCount--;
        }

        /********************************************************************
         * 
         * An ArrayPanel holds n ImagePanel.
         * A Frame (representing an input or output document) holds one
         * ArrayPanel.
         */

        public class ArrayPanel : Panel
        {    
            private int m_imagePanelCount = 0;

            public void Add(ImagePanel imagePanel)
            {
                imagePanel.Location = new Point((m_imagePanelCount) * (2 + ImagePanel.imageSize), 0);
                this.Controls.Add(imagePanel);
                m_imagePanelCount++;
                imagePanel.SetOutputPageNum(m_imagePanelCount);
            }
            public void Clear()
            {
                this.Controls.Clear();
                m_imagePanelCount = 0;
            }
            public int GetImagePanelCount()
            {
                return m_imagePanelCount;
            }
            public void Insert(ImagePanel imagePanelNew, int /*0-based*/position)
            {
                imagePanelNew.Location = new Point((position) * (2 + ImagePanel.imageSize), 0);
                this.Controls.Add(imagePanelNew);
                foreach (ImagePanel imagePanel in this.Controls)
                    if (imagePanel.GetOutputPageNum() > position)
                    {
                        imagePanel.Left += ImagePanel.width;
                        imagePanel.SetOutputPageNum(imagePanel.GetOutputPageNum() + 1);
                    }
                m_imagePanelCount++;
                imagePanelNew.SetOutputPageNum(position + 1);
            }
            public void Remove(ImagePanel imagePanelDel)
            {
                int iPosition = imagePanelDel.GetOutputPageNum();
                this.Controls.Remove(imagePanelDel);
                foreach (ImagePanel imagePanel in this.Controls)
                    if (imagePanel.GetOutputPageNum() > iPosition)
                    {
                        imagePanel.Left -= ImagePanel.width;
                        imagePanel.SetOutputPageNum(imagePanel.GetOutputPageNum() - 1);
                    }
                m_imagePanelCount--;
            }
        }

        /********************************************************************
         * 
         * An ImagePanel represents a preview of one page. It contains
         * an image and a page number.
         * It supports mouse events, so the "page" can be drag&dropped
         * from an input to an output document.
         */

        public class ImagePanel : Panel
        {
            public static int imageSize = 59;
            public static int width = imageSize + Frame.m_offset;

            private readonly int m_inputPageNum;
            private readonly int m_inputPdfNum;
            private int m_outputPageNum;

            public ImagePanel(ImagePanel imagePanelOrg)
            {
                this.m_inputPageNum = imagePanelOrg.m_inputPageNum;
                this.m_inputPdfNum = imagePanelOrg.m_inputPdfNum;
                this.AllowDrop = true;

                // Copy Controls
                foreach (Control controlOrg in imagePanelOrg.Controls)
                {
                    if (controlOrg.GetType() == typeof(Panel))
                    {
                        Panel panelOrg = (Panel)controlOrg;
                        Panel panel = new Panel();
                        panel.AutoScroll = panelOrg.AutoScroll;
                        panel.Size = panelOrg.Size;
                        panel.Location = panelOrg.Location;
                        panel.BackColor = panelOrg.BackColor;
                        panel.BorderStyle = panelOrg.BorderStyle;
                        panel.BackgroundImage = new Bitmap(panelOrg.BackgroundImage);
                        panel.BackgroundImageLayout = panelOrg.BackgroundImageLayout;
                        panel.MouseDown += new MouseEventHandler(ImagePanel_MouseDownOut);
                        this.Controls.Add(panel);
                    }
                    else if (controlOrg.GetType() == typeof(Label))
                    {
                        Label labelOrg = (Label)controlOrg;
                        Label label = new Label();
                        label.Text = m_inputPdfNum.ToString() + ": (" + m_inputPageNum.ToString() + ")";
                        label.Size = labelOrg.Size;
                        label.BorderStyle = labelOrg.BorderStyle;
                        label.TextAlign = labelOrg.TextAlign;
                        label.Location = labelOrg.Location;
                        this.Controls.Add(label);
                    }
                }
                this.Size = imagePanelOrg.Size;
                this.DragDrop += new DragEventHandler(ImagePanel_DragDrop);
                this.DragOver += new DragEventHandler(ImagePanel_DragOver);

            }
            public ImagePanel(int inputPageNum, int inputPdfNum, String imagePath)
            {
                this.m_inputPageNum = inputPageNum;
                this.m_inputPdfNum = inputPdfNum;
                this.m_outputPageNum = 0;

                // Add Panel with image and page number
                Panel panel = new Panel();
                panel.AutoScroll = false;
                panel.Size = new Size(imageSize, imageSize);
                panel.Location = new Point(Frame.m_offset, Frame.m_offset);
                panel.BackColor = Color.Transparent;
                panel.BorderStyle = BorderStyle.Fixed3D;
                Image image = new Bitmap(imagePath);
                panel.BackgroundImage = new Bitmap(image);
                image.Dispose();
                System.IO.File.Delete(imagePath);
                panel.BackgroundImageLayout = ImageLayout.Center;
                panel.BackColor = g_colorDarkGray;
                panel.MouseDown += new MouseEventHandler(ImagePanel_MouseDownIn);
                this.Controls.Add(panel);

                Label label = new Label();
                label.Text = "(" + inputPageNum.ToString() + ")";
                label.Size = new Size(imageSize, 15);
                label.BorderStyle = BorderStyle.Fixed3D;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Location = new Point(Frame.m_offset, imageSize + Frame.m_offset);
                this.Controls.Add(label);

                this.Size = new Size(width, imageSize + Frame.m_offset + label.Size.Height);
            }
            public int GetInputPageNum()
            {
                return m_inputPageNum;
            }
            public int GetOutputPageNum()
            {
                return m_outputPageNum;
            }
            public int GetPdfNum()
            {
                return m_inputPdfNum;
            }
            public void SetOutputPageNum(int iNewVal)
            {
                m_outputPageNum = iNewVal;
            }
            protected void ImagePanel_MouseDownIn(object sender, MouseEventArgs e)
            {
                this.DoDragDrop(this, DragDropEffects.Copy);
            }
            protected void ImagePanel_MouseDownOut(object sender, MouseEventArgs e)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Items.Add(Resources.strDeletePage);
                contextMenuStrip.Items[0].MouseDown += new MouseEventHandler(ImagePanel_MouseDownDelete);
                contextMenuStrip.Items.Add(Resources.strDeleteAllPages);
                contextMenuStrip.Items[1].MouseDown += new MouseEventHandler(ImagePanel_MouseDownDeleteAll);
                this.ContextMenuStrip = contextMenuStrip;
            }
            protected void ImagePanel_MouseDownDelete(object sender, MouseEventArgs e)
            {
                OutputFrame outputFrame = (OutputFrame)this.Parent.Parent;
                outputFrame.GetArrayPanel().Remove(this);
            }
            protected void ImagePanel_MouseDownDeleteAll(object sender, MouseEventArgs e)
            {
                OutputFrame outputFrame = (OutputFrame)this.Parent.Parent;
                outputFrame.GetArrayPanel().Clear();
            }
            private void ImagePanel_DragDrop(object sender, DragEventArgs e)
            {
                if (!e.Data.GetDataPresent(typeof(ImagePanel)))
                    return;
                ImagePanel imagePanel = new ImagePanel((ImagePanel)e.Data.GetData(typeof(ImagePanel)));
                OutputFrame outputFrame = (OutputFrame)this.Parent.Parent;
                outputFrame.GetArrayPanel().Insert(imagePanel, this.m_outputPageNum - 1);
            }
            private void ImagePanel_DragOver(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /********************************************************************
         * 
         *  This abstract class is a panel that represents one document.
         */

        public abstract class Frame : Panel
        {
            public static readonly int m_offset = 2;
            private static readonly int m_offsetPreview = 140;

            protected readonly int m_instance;
            protected readonly ArrayPanel m_arrayPanel;   
            protected Label m_labelPageCount, m_labelFilename;
            protected String m_fileName;      

            public Frame(int width, int height, int instance)
            {
                this.m_instance = instance;

                // Background Panel
                this.Width = width;
                this.Height = height;
                this.Dock = DockStyle.Top;
                this.Location = new Point(0, 0);
                this.BorderStyle = BorderStyle.FixedSingle;

                // Filename Text
                m_labelFilename = new Label();
                m_labelFilename.Size = new Size(120, 25);
                m_labelFilename.Text = String.Empty;
                m_labelFilename.Location = new Point(10, 25);
                m_labelFilename.BackColor = Color.Transparent;
                m_labelFilename.Font = new Font(m_labelFilename.Font.FontFamily,
                                                m_labelFilename.Font.Size,
                                                FontStyle.Bold);
                this.Controls.Add(m_labelFilename);

                // Number of Pages Label
                m_labelPageCount = new Label();
                m_labelPageCount.Size = new Size(80, 15);
                m_labelPageCount.Text = "0" + Resources.strPages;
                m_labelPageCount.Location = new Point(10, 50);
                m_labelPageCount.BackColor = Color.Transparent;
                this.Controls.Add(m_labelPageCount);

                // Image-Preview Array Panel
                m_arrayPanel = new ArrayPanel();
                m_arrayPanel.AutoScroll = true;                
                m_arrayPanel.Size = new Size(width - m_offsetPreview - 4, height - 6);
                m_arrayPanel.Location = new Point(m_offsetPreview, 2);
                m_arrayPanel.BackColor = Color.WhiteSmoke;
                m_arrayPanel.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(m_arrayPanel);

                // Close Button
                Button button = new Button();
                button.Size = new Size(50, 25);
                button.Location = new Point(70, 70);
                button.BackColor = g_colorBlue;
                button.ForeColor = Color.White;
                button.Text = Resources.strClose;
                button.Click += new EventHandler(this.ButtonClose_Click);
                this.Controls.Add(button);

                this.Resize += new EventHandler(Frame_Resize);
            }
            public ArrayPanel GetArrayPanel()
            {
                return m_arrayPanel;
            }
            public int GetInstance()
            {
                return m_instance;
            }
            protected void Frame_Resize(object sender, EventArgs e)
            {
                m_arrayPanel.Size = new Size(Width - m_offsetPreview - 4, Height - 6);
            }
            protected abstract void ButtonClose_Click(object sender, EventArgs e);
        }

        /********************************************************************
         * 
         * This panel represents one input document.
         * It contains labels holding information about the document and
         * a buttons to clear the document. 
         */

        public sealed class InputFrame : Frame
        {
            private InDoc m_input;

            public InputFrame(int width, int height, int instance)
                : base(width, height, instance)
            {
                // Instance Count Label
                Label label = new Label();
                label.Size = new Size(80, 25);
                label.Text = Resources.strInputPDF + instance.ToString();
                label.Location = new Point(10, 10);
                label.BackColor = Color.Transparent;
                this.Controls.Add(label);
                this.BackColor = g_colorGray;
            }
            public bool Open(int pageLimit)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                m_fileName = openFileDialog.FileName;
                try
                {
                    base.m_labelFilename.Text = m_fileName.Substring(m_fileName.LastIndexOf('\\') + 1,
                                                m_fileName.Length - m_fileName.LastIndexOf('\\') - 1);
                }
                catch
                {
                    m_fileName = String.Empty;
                }
                try
                {
                    m_input = new InDoc();
                }
                catch (DllNotFoundException ex)
                {
                    MessageBox.Show(ex.Message + Resources.MsgDLLNotFound);
                    return false;
                }
                if (!m_input.Open(m_fileName, String.Empty))
                {
                    m_labelFilename.Text = String.Empty;
                    MessageBox.Show("Error: " + m_input.ErrorCode + " (" + m_input.ErrorMessage + ")", "Error opening input file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                m_labelPageCount.Text = m_input.PageCount.ToString() + Resources.strPages;

                using (Converter conv = new Converter())
                {
                    if (!conv.Open(m_fileName, String.Empty))
                    {
                        MessageBox.Show("Error: " + conv.ErrorCode, "Error opening input file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    conv.RotateMode = Pdftools.Render.PDFRotateMode.eRotateAttribute;

                    m_arrayPanel.Clear();
                    String imagePath = Resources.strTempFile;
                    int i;
                    int pageCount = Math.Min(pageLimit, conv.PageCount);
                    for (i = 1; i <= pageCount; i++)
                    {
                        Application.DoEvents();
                        // better: Convert pages to images on demand
                        if (!conv.CreateImage(imagePath))
                            break;
                        conv.SetBitmapDimensions(0, ImagePanel.imageSize);
                        conv.RenderPage(i);
                        conv.CloseImage();
                        m_arrayPanel.Add(new ImagePanel(i, m_instance, imagePath));
                    }
                    conv.Close();
                }
                return true;
            }
            public InDoc GetInput()
            {
                return m_input;
            }
            protected override void ButtonClose_Click(object sender, EventArgs e)
            {
                Control parent = Parent;
                while (!(parent is PdfMergeSplitForm))
                    parent = parent.Parent;
                bool hideOnly = true;
                ((PdfMergeSplitForm)parent).RemoveInputFrame(this, hideOnly);
                if (!hideOnly)
                {
                    if (m_input != null)
                        m_input.Close();
                    this.Dispose();
                    if (m_input != null)
                        m_input.Dispose();
                }
            }
        }

        /********************************************************************
         * 
         * This panel represents one output documents.
         * It contains labels holding information about the document and
         * buttons to save and clear the document. 
         */
        public sealed class OutputFrame : Frame
        {
            private OutDoc m_output;

            public OutputFrame(int width, int height, int instance)
                : base(width, height, instance)
            {
                m_arrayPanel.AllowDrop = true;
                m_arrayPanel.DragEnter += new DragEventHandler(PanelArray_DragEnter);
                m_arrayPanel.DragDrop  += new DragEventHandler(PanelArray_DragDrop);
                m_arrayPanel.DragLeave += new EventHandler(PanelArray_DragLeave);
                m_arrayPanel.DragOver  += new DragEventHandler(PanelArray_DragOver);
                
                // Instance Count Label
                Label label = new Label();
                label.Size = new Size(80, 25);
                label.Text = Resources.strOuputPDF + instance.ToString();
                label.Location = new Point(10, 10);
                label.BackColor = Color.Transparent;
                this.Controls.Add(label);
                
                // File Select Button
                Button button = new Button();
                button.Size = new Size(50, 25);
                button.Location = new Point(10, 70);
                button.BackColor = g_colorBlue;
                button.ForeColor = Color.White;
                button.Text = Resources.strSave;
                button.Click += new EventHandler(this.ButtonSave_Click);
                this.Controls.Add(button);

                this.BackColor = Color.DarkGray;
            }
            protected override void ButtonClose_Click(object sender, EventArgs e)
            {
                if (m_output != null)
                    m_output.Close();
                Control parent = Parent;
                while (!(parent is PdfMergeSplitForm))
                    parent = parent.Parent;
                ((PdfMergeSplitForm)parent).RemoveOutputFrame(this);
                this.Dispose();
            }
            private void PanelArray_DragEnter(object sender, DragEventArgs e)
            {
                m_arrayPanel.BackColor = Color.Gray;
            }
            private void PanelArray_DragDrop(object sender, DragEventArgs e)
            {
                m_arrayPanel.BackColor = Color.WhiteSmoke;
                if (!e.Data.GetDataPresent(typeof(ImagePanel)))
                    return;
                ImagePanel imagePanel = new ImagePanel((ImagePanel)e.Data.GetData(typeof(ImagePanel)));

                // Add at end
                m_arrayPanel.Add(imagePanel);
            }
            private void PanelArray_DragLeave(object sender, EventArgs e)
            {
                m_arrayPanel.BackColor = Color.WhiteSmoke;
            }
            private void PanelArray_DragOver(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
            private void ButtonSave_Click(object sender, EventArgs e)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                m_fileName = saveFileDialog.FileName;
                using (m_output = new OutDoc())
                {
                    if (!m_output.Create(m_fileName,
                                         String.Empty,
                                         String.Empty,
                                         PDFPermission.ePermNoEncryption))
                    {
                        MessageBox.Show(Resources.msgSaveFileErr);
                        return;
                    }

                    // Get ArrayPanel
                    ArrayPanel arrayPanel = null;
                    foreach (Object obj in this.Controls)
                        if (obj.GetType().Equals(typeof(ArrayPanel)))
                            arrayPanel = (ArrayPanel)obj;
                    if (arrayPanel == null)
                        return;

                    /* Get all pages and copy them
                     * 
                     * The following approach is inefficient (n^2), but simple to implement.
                     * More efficent would be to quick-sort pages 1st.
                     */
                    PDFCopyOptions copyOption = PDFCopyOptions.ePdfCopyAnnotations |
                        PDFCopyOptions.ePdfCopyAssociatedFiles |
                        PDFCopyOptions.ePdfCopyFormFields |
                        PDFCopyOptions.ePdfCopyLinks |
                        PDFCopyOptions.ePdfCopyLogicalStructure |
                        PDFCopyOptions.ePdfCopyOutlines |
                        PDFCopyOptions.ePdfMergeOCGs |
                        PDFCopyOptions.ePdfSeparateAcroForms;
                    Control parent = Parent;
                    while (!(parent is PdfMergeSplitForm))
                        parent = parent.Parent;
                    int pageCount = 0;
                    foreach (ImagePanel imagePanel in arrayPanel.Controls)
                        pageCount++;
                    for (int i = 1; i <= pageCount; i++)
                        foreach (ImagePanel imagePanel in arrayPanel.Controls)
                            if (imagePanel.GetOutputPageNum() == i)
                                m_output.CopyPages2(((PdfMergeSplitForm)parent).GetInput(imagePanel.GetPdfNum()),
                                                   imagePanel.GetInputPageNum(),
                                                   imagePanel.GetInputPageNum(), copyOption);
                    m_output.Close();
                    m_labelFilename.Text = m_fileName.Substring(m_fileName.LastIndexOf('\\') + 1,
                                             m_fileName.Length - m_fileName.LastIndexOf('\\') - 1);
                    m_labelPageCount.Text = pageCount.ToString() + Resources.strPages;
                }
            }
        }
    }
}