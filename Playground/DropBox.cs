using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Stone;

namespace Playground
{
    public class DropBox
    {
        private static string _accessKey = "TZA8oYblUYYAAAAAAAAcbvczXR-a3bG4ogbTIv68k1rFzXmLCLsDpZg2L9xTR1E1";

        public DropBox()
        {
        }

        public async Task getFoldersList()
        {
            using (DropboxClient client = new DropboxClient(_accessKey))
            {
                try
                {
                    //ListFolderArg args = new ListFolderArg("", true, false, false, false);


                    bool more = true;
                    var list = await client.Files.ListFolderAsync("");
                    while (more)
                    {
                        foreach (var item in list.Entries.Where(i => i.IsFile))
                        {
                            // Process the file
                        }
                        more = list.HasMore;
                        if (more)
                        {
                            list = await client.Files.ListFolderContinueAsync(list.Cursor);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Process the exception
                }
            }
        }

		public async Task DownloadFile(string filename, Stream s)
		{
			using (DropboxClient client = new DropboxClient(_accessKey))
			{
				IDownloadResponse<FileMetadata> resp =
					await client.Files.DownloadAsync(filename);
				Stream ds = await resp.GetContentAsStreamAsync();
				await ds.CopyToAsync(s);
				ds.Dispose();
			}
		}
    }
}
