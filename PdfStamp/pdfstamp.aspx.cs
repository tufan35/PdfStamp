using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Image = iTextSharp.text.Image;

namespace PdfStamp
{
    public partial class pdfstamp1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            if (fuUpload.HasFile)
            {

                fuUpload.SaveAs(Server.MapPath("~//Upload//" + fuUpload.FileName));
            }
            else
            {
                Label1.Text = "Yüklenmedi";
            }
        }

        protected void download(object sender, EventArgs e)
        {
            string dosyayolu = Server.MapPath("~//Upload//teststamp.pdf");
            FileInfo file = new FileInfo(dosyayolu);
            if (file.Exists)
            {


                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=teststamp.pdf");
                Response.TransmitFile(Server.MapPath("~//Upload//teststamp.pdf"));
                Response.End();
            }
            else
            {
                Label1.Text = "indirilmedi.";
            }
        }

        protected void View(object sender, EventArgs e)
        {
            string Test = "https://localhost:44374/Upload/teststamp.pdf";
            frm_docs.Src = Test;




        }


        protected void Btnstamp(object sender, EventArgs e)
        {

            damga("C://Users//tufanc//source//repos//PdfStamp//PdfStamp//stampimage", "C://Users//tufanc//source//repos//PdfStamp//PdfStamp//Upload//teststamp.pdf");



        }

        #region Damga Ekleme (Stamp)

        private void damga(string resimdosyası, string dosyayolu)
        {


            byte[] bytes = File.ReadAllBytes(dosyayolu);

            PdfContentByte waterMark;

            using (MemoryStream stream = new MemoryStream())
            {


                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {


                    int sayfa = reader.NumberOfPages;
                    for (int j = 1; j <= sayfa; j++)
                    {
                        int imzax = 1;
                        int imzay = 0;


                        waterMark = stamper.GetUnderContent(j);


                        for (int isim = 0; isim < ListBox2.Items.Count; isim++)
                        {


                            if (ListBox2.Items[isim].Selected)

                            {
                                string yol = Server.MapPath(ListBox2.Items[isim].Value);
                                var resim = iTextSharp.text.Image.GetInstance(yol);

                                imzax = imzax + 70;
                                imzay = imzay + 0;

                                resim.SetAbsolutePosition(imzax, imzay);


                                waterMark.AddImage(resim);

                            }

                        }

                    }

                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(dosyayolu, bytes);

        }

    #endregion

    }
}