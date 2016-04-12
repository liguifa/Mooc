using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.ViewModels
{
    public class IndexModel
    {
        #region InformationScience
        public string InformationScienceTitle = "信息科学";

        public string InformationScienceLinkText1 = "C# 6.0";

        public string InformationScienceLinkText2 = "Nodejs Web";

        public List<StudentClient.Models.Cours> InformationScience { get; set; }
        #endregion

        #region ArtDesign
        public string ArtDesignTitle = "艺术设计";

        public string ArtDesignLinkText1 = "植物之型";

        public string ArtDesignLinkText2 = "建筑之美";

        public List<StudentClient.Models.Cours> ArtDesign { get; set; }
        #endregion

        #region LifeSciences

        public string LifeSciencesTitle = "生命科学";

        public string LifeSciencesLinkText1 = "生命之美";

        public string LifeSciencesLinkText2 = "人类密码";

        public List<StudentClient.Models.Cours> LifeSciences { get; set; }
        #endregion

        #region LanguageHistory
        public string LanguageHistoryTitle = "语言文史";

        public string LanguageHistoryLinkText1 = "中古奇观";

        public string LanguageHistoryLinkText2 = "语言之初";
        public List<StudentClient.Models.Cours> LanguageHistory { get; set; }
        #endregion

        #region TextileScience
        public string TextileScienceTitle = "纺织科学";

        public string TextileScienceLinkText1 = "纺织技术";

        public string TextileScienceLinkText2 = "印花之术";

        public List<StudentClient.Models.Cours> TextileScience { get; set; } 
        #endregion
    }
}
