using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            

            lblLocationCount.Text = db.Location.Count().ToString();

            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = string.Format("{0:F2}", db.Location.Average(x => x.LocationCapacity));
            lblAvgLocationPrice.Text= string.Format("{0:F2}₺", db.Location.Average(x=>x.LocationPrice));

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text=db.Location.Where(x=>x.LocationId == lastCountryId).Select(y=>y.LocationCountry).FirstOrDefault();
            lblCapadociaLocationCapacity.Text=db.Location.Where(x=>x.LocationCity=="Kapadokya").Select(y =>y.LocationCapacity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text=db.Location.Where(x=>x.LocationCountry=="Türkiye").Average(y=>y.LocationCapacity).ToString();

            var romeGuideId = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text=db.Location.Where(x=>x.LocationPrice==maxPrice).Select(y=>y.LocationCity).FirstOrDefault().ToString(); 

            var guideIdBarısAlper=db.Guide.Where(x=>x.GuideName=="Barış" &&  x.GuideSurname=="Alper").Select(y => y.GuideId).FirstOrDefault();
            lblBarısAlperLocationCount.Text=db.Location.Where(x=>x.GuideId == guideIdBarısAlper).Count().ToString();

        }

        private void lblRomeGuideName_Click(object sender, EventArgs e)
        {

        }
    }
}
