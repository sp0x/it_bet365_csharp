/// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool WriteXlsPostsReport(string filePath)
        {
            Documents.XlsConverter<IPagePost> xlm = new Documents.XlsConverter<IPagePost>();
            dynamic dtx = DateTime.Now;
            dynamic epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dynamic unixDateTime = (dtx.ToUniversalTime() - epoch).TotalSeconds;

            xlm.MapColumn(x => x.Created);
            xlm.MapColumn(x => x.Type);
            xlm.MapColumn(x => x.Message);
            xlm.MapColumn(x => x.Likes.Count(), "Likes Count");
            xlm.MapColumn(x => x.ShareCount);
            xlm.MapColumn(x => x.Link);
            xlm.MapColumn(x => x.Picture);
            xlm.MapColumn(x => x.Video);

            return xlm.Convert(mPosts, filePath, string.Format("Report for page {0} from {1}", PageName, DateTime.Now.ToString("mm.dd.yyyy")));
        }