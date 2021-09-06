using System;

namespace BurgerBackend.Models
{
    public class BurgerPlace
    {
        public ulong m_ID_u64 { get; set; }
        public string m_BPName_s { get; set; }
        public Location m_Location_r { get; set; }
        public string m_Information_s { get; set; }
        public string m_OpeningTimes_s { get; set; }
    }

    public class ReviewScore
    {
        public ReviewScore(float f_Taste_f, float f_Texture_f, float f_VisualRepresentation_f)
        {
            m_Taste_f = f_Taste_f;
            m_Texture_f = f_Texture_f;
            m_VisualRepresentation_f = f_VisualRepresentation_f;
            CalcSumScore();
            m_CreationTime_r = DateTime.Now;
        }

        private void CalcSumScore()
        {
            m_SumScore_f = 0;
            m_SumScore_f = (m_Taste_f + m_Texture_f + m_VisualRepresentation_f) / 3;
        }

        public ulong m_ID_u64 { get; set; }
        public string m_UserIdentification_s { get; set; }
        public ulong m_BPID_u64 { get; set; }
        public float m_SumScore_f { get; set; }
        public float m_Taste_f { get; set; }
        public float m_Texture_f { get; set; }
        public float m_VisualRepresentation_f { get; set; }
        public DateTime m_CreationTime_r { get; set; }
    }

    public class Location
    {
        public Location GetMyLocation() { return new Location(); }
    }

    public class Picture
    {
        public Picture(ulong f_ReviewScoreID_u64, string f_Path_s)
        {
            m_ReviewScoreID_u64 = f_ReviewScoreID_u64;
            m_Path_s = f_Path_s;
        }
        public ulong m_ReviewScoreID_u64 { get; set; }
        public string m_Path_s { get; set; }
    }
}
