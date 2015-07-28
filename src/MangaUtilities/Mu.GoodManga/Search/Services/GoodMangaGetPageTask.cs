using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mu.Core.Search;

namespace Mu.GoodManga.Search.Services
{
    public class GoodMangaGetPageTask : GetPageTaskBase
    {
        private readonly MangaInformation _mangaInformation;
        private readonly ChapterInformation _chapterInformation;
        private readonly int _page;

        private string _imagePath;

        public GoodMangaGetPageTask(
            MangaInformation pMangaInformation,
            ChapterInformation pChapterInformation,
            int pPage)
        {
            _mangaInformation = pMangaInformation;
            _chapterInformation = pChapterInformation;
            _page = pPage;
        }

        public override void Do()
        {
            _imagePath = Path.Combine(Environment.CurrentDirectory, "TestImages", "TestImage01.png");
            var b = BitmapSource.Create(100, 100, 96, 96, PixelFormats.Bgr24, BitmapPalettes.WebPalette, new Byte[100*(100/8)], 100/8);
            using (var fs = File.Create(_imagePath))
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(b));
                encoder.Save(fs);
                fs.Close();
            }
        }

        public override object GetResult()
        {
            return new GoodMangaGetPageResult
            {
                Filepath = _imagePath
            };
        }
    }
}
