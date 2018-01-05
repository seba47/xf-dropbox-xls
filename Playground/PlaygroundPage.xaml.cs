using System.IO;
using System.Threading.Tasks;
using Playground.Interfaces;
using Xamarin.Forms;

namespace Playground
{
    public partial class PlaygroundPage : ContentPage
    {
        MemoryStream stm = new MemoryStream();
        public PlaygroundPage()
        {
            InitializeComponent();

            Device.BeginInvokeOnMainThread(
            async () =>
            {
                DropBox db = new DropBox();
                //await db.getFoldersList();
                await db.DownloadFile("/spreadsheet1.xls", stm);
                MemoryStream memstr = new MemoryStream(stm.ToArray());
                var obj = DependencyService.Get<IXlsParser>().Parse(memstr);

            });
        }
    }
}
