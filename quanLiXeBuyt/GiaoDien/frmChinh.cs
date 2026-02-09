using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using quanLiXeBuyt.DuLieu;

namespace quanLiXeBuyt.GiaoDien
{
    
    public partial class frmChinh : Form
    {
        private GMapControl map;
        KetNoiCSDL db = new KetNoiCSDL();
        public frmChinh()
        {
            InitializeComponent();
            KhoiTaoBanDo();
            HienThiTramDungLongXuyen();
        }
        private void KhoiTaoBanDo()
        {
            map = new GMapControl();
            map.MapProvider = GMapProviders.GoogleMap;
            map.Dock = DockStyle.Fill;

            map.Position = new PointLatLng(10.3734, 105.4372);
            map.MinZoom = 5;
            map.MaxZoom = 20;
            map.Zoom = 14;
            map.DragButton = MouseButtons.Left;

            pnlNoiDung.Controls.Add(map);
        }
        private void HienThiTramDungLongXuyen()
        {
            // Lấy đúng tên bảng 'Stops' trong Database của bạn
            string sql = "SELECT * FROM stops";
            DataTable dt = db.LayDuLieu(sql);

            GMapOverlay markersOverlay = new GMapOverlay("tram_dung");

            foreach (DataRow row in dt.Rows)
            {
                double lat = Convert.ToDouble(row["Latitude"]);
                double lng = Convert.ToDouble(row["Longitude"]);
                string tenTram = row["StopName"].ToString();

                // Tạo marker ghim màu đỏ
                GMapMarker marker = new GMarkerGoogle(
                    new PointLatLng(lat, lng),
                    GMarkerGoogleType.red_pushpin
                );

                marker.ToolTipText = "Trạm: " + tenTram;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                markersOverlay.Markers.Add(marker);
            }
            map.Overlays.Add(markersOverlay);
        }




        private void pnlChucNang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlNoiDung_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
