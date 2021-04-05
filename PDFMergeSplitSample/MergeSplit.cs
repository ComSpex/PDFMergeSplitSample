/* This is a C#.NET sample for the 3-Heights PDF Merge Split API
 * from PDF Tools AG (www.pdf-tools.com) for MS Visual Studio 2005.
 * 
 * Copyright (C) 2008-2018 PDF Tools AG, Switzerland
 * Permission to use, copy, modify, and distribute this
 * software and its documentation for any purpose and without
 * fee is hereby granted, provided that the above copyright
 * notice appear in all copies and that both that copyright
 * notice and this permission notice appear in supporting
 * documentation.  This software is provided "as is" without
 * express or implied warranty.
 * as of 05Apr2021 for a month.
 * License : 1-LCAA4-NSJ0R-8XMCM-RAEXK-9B196-TV6XE-1MV3F
 */

using System;
using System.Windows.Forms;
using Pdftools.PdfSplMrg;
using Pdftools.Pdf;
using PDFMergeSplitSample.Properties;

namespace PDFMergeSplitSample {
  public partial class MergeSplit : Form {
    public MergeSplit() {
      InitializeComponent();
    }

    // The options for copying pages from an input document to an output document
    private PDFCopyOptions copyOptions = PDFCopyOptions.ePdfCopyAnnotations |
                        PDFCopyOptions.ePdfCopyAssociatedFiles |
                        PDFCopyOptions.ePdfCopyFormFields |
                        PDFCopyOptions.ePdfCopyLinks |
                        PDFCopyOptions.ePdfCopyLogicalStructure |
                        PDFCopyOptions.ePdfCopyNamedDestinations |
                        PDFCopyOptions.ePdfCopyOutlines |
                        PDFCopyOptions.ePdfMergeOCGs |
                        PDFCopyOptions.ePdfSeparateAcroForms;

    private void btnBrowseInput1_Click(object sender, EventArgs e) {
      try {
        openFileDialog1.FileName = txtInput1.Text;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
          txtInput1.Text = openFileDialog1.FileName;
      } catch (InvalidOperationException) {
        txtInput1.Text = String.Empty;
        return;
      }
    }

    private void btnBrowseInput2_Click(object sender, EventArgs e) {
      try {
        openFileDialog1.FileName = txtInput2.Text;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
          txtInput2.Text = openFileDialog1.FileName;
      } catch (InvalidOperationException) {
        txtInput2.Text = String.Empty;
        return;
      }
    }

    private void btnOutput_Click(object sender, EventArgs e) {
      try {
        saveFileDialog1.FileName = txtOutput.Text;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
          txtOutput.Text = saveFileDialog1.FileName;
      } catch (InvalidOperationException) {
        txtOutput.Text = String.Empty;
        return;
      }
    }

    private void btnMerge_Click(object sender, EventArgs e) {
      // Merge the first and second input PDF file
      try {
        // Verify fields are not empty
        if (txtInput1.Text.Equals(String.Empty) ||
            txtInput2.Text.Equals(String.Empty) ||
            txtOutput.Text.Equals(String.Empty)) {
          MessageBox.Show(Resources.MsgNoFileSelected);
          return;
        }

        using (InDoc input1 = new InDoc(), input2 = new InDoc()) {
          using (OutDoc output = new OutDoc()) {
            // Create the output document
            if (!output.Create(txtOutput.Text, String.Empty, String.Empty, PDFPermission.ePermNoEncryption)) {
              MessageBox.Show(Resources.MsgOutputNotCreated + " " + txtOutput.Text + "\nError: " + output.ErrorCode + " (" + output.ErrorMessage + ")");
              return;
            }

            // Open the first input PDF file
            if (!input1.Open(txtInput1.Text, String.Empty)) {
              if (input1.ErrorCode == PDFErrorCode.PDF_E_FILEOPEN)
                MessageBox.Show(Resources.MsgFileNotFound + " " + txtInput1.Text);
              else
                MessageBox.Show(Resources.MsgFileNotOpen + " " + txtInput1.Text + "\nError: " + input1.ErrorCode + " (" + input1.ErrorMessage + ")");
              output.Close();
              return;
            }
            // Open the second input PDF file
            if (!input2.Open(txtInput2.Text, String.Empty)) {
              if (input2.ErrorCode == PDFErrorCode.PDF_E_FILEOPEN)
                MessageBox.Show(Resources.MsgFileNotFound + " " + txtInput2.Text);
              else
                MessageBox.Show(Resources.MsgFileNotOpen + " " + txtInput2.Text + "\nError: " + input2.ErrorCode + " (" + input2.ErrorMessage + ")");
              input1.Close();
              output.Close();
              return;
            }

            // Set the default document attributes to input 1
            output.CopyAttributes(input1);

            // Merge all pages from the first input document
            output.CopyPages2(input1, 1, -1, copyOptions);
            // Merge all pages from the second input document
            output.CopyPages2(input2, 1, -1, copyOptions);

            // Copy embedded files from the first input document
            output.CopyEmbeddedFiles(input1, false);
            // Copy embedded files from the second input document
            output.CopyEmbeddedFiles(input2, false);

            // Set a new title
            output.Title = Resources.StrTitleMerge;

            input1.Close();
            input2.Close();
            output.Close();
          }
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnSplit_Click(object sender, EventArgs e) {
      /* Split the first input PDF file into two output PDF files.
       * The first output PDF file is named <OutputFileName>split1.pdf 
       * and contains the pages 1 and 2 of the input file 
       * and the second output PDF file is named <OutputFileName>split2.pdf
       * and contains the pages 3 and following. */
      try {
        // Verify fields are not empty
        if (txtInput1.Text.Equals(String.Empty) ||
            txtOutput.Text.Equals(String.Empty)) {
          MessageBox.Show(Resources.MsgNoFileSelected);
          return;
        }

        using (InDoc input1 = new InDoc()) {
          using (OutDoc output1 = new OutDoc(), output2 = new OutDoc()) {
            // Create the first output PDF file
            if (!output1.Create(txtOutput.Text + "split1.pdf", String.Empty, String.Empty, PDFPermission.ePermNoEncryption)) {
              MessageBox.Show(Resources.MsgOutputNotCreated + " " + txtOutput.Text + "split1.pdf" + "\nError: " + output1.ErrorCode + " (" + output1.ErrorMessage + ")");
            } else {
              // Create the second output PDF file
              if (!output2.Create(txtOutput.Text + "split2.pdf", String.Empty, String.Empty, PDFPermission.ePermNoEncryption)) {
                MessageBox.Show(Resources.MsgOutputNotCreated + " " + txtOutput.Text + "split2.pdf" + "\nError: " + output2.ErrorCode + " (" + output2.ErrorMessage + ")");
              } else {
                // Open the first input file
                if (!input1.Open(txtInput1.Text, String.Empty)) {
                  if (input1.ErrorCode == PDFErrorCode.PDF_E_FILEOPEN)
                    MessageBox.Show(Resources.MsgFileNotFound + " " + txtInput1.Text);
                  else
                    MessageBox.Show(Resources.MsgFileNotOpen + " " + txtInput1.Text + "\nError: " + input1.ErrorCode + " (" + input1.ErrorMessage + ")");
                } else {
                  // set the default documet attribute to the input
                  output1.CopyAttributes(input1);
                  output2.CopyAttributes(input1);

                  // Set the new titles
                  output1.Title = Resources.StrTitleSplit1;
                  output2.Title = Resources.StrTitleSplit2;

                  // Split page 1 and 2 from the input PDF file
                  output1.CopyPages2(input1, 1, 2, copyOptions);
                  // Split page 3 and the following pages from the input PDF file
                  output2.CopyPages2(input1, 3, -1, copyOptions);
                  input1.Close();
                }
                output2.Close();
              }
              output1.Close();
            }
          }
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }
  }

  static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MergeSplit());
    }
  }
}