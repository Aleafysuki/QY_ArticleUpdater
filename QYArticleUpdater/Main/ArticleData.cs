using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYArticleUpdater.Main
{
	public class ArticleData
	{
		public string Title { get; set; }
		public string ShortTitle { get; set; }
		public string TagId { get; set; }
		public int GameId { get; set; }
		public int ColumnId { get; set; }
		public string Source { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string ZhDetail { get; set; }
		public string ImagePath { get; set; }
		public int AdminId { get; set; }
		public string Sign { get; set; }
	}
}
