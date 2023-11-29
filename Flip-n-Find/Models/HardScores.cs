using PropertyChanged;
using SQLite;

namespace Flip_n_Find.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("HardScores")]
    public class HardScores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TimeTaken { get; set; }
        public int MoveCount { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
