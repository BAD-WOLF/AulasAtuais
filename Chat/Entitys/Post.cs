namespace Chat.Entitys {
    using System.Text;

    internal class Post(DateTime moment, String title, String about, Int32 likes) {
        private DateTime _moment = moment;
        private String _title = title;
        private String _about = about;
        private Int32 _likes = likes;
        private List<Comments> _comments = new List<Comments> { };

        internal DateTime Moment { get => this._moment; set => this._moment = value; }
        internal String Title { get => this._title; set => this._title = value; }
        internal String Content { get => this._about; set => this._about = value; }
        internal Int32 Likes { get => this._likes; set => this._likes = value; }
        public List<Comments> LComments { get => this._comments; private set => this._comments = value ; }

        public void AddCommits(Comments value) {
            this._comments.Add(value);
        }

        public override String ToString() {
            String handler = $"Moment: {this.Moment}\nTitle: {this.Title}\nContent: {this.Content}\nLikes: {this.Likes}\n[Comments]\n";
            StringBuilder sb = new StringBuilder().Append(handler);
            for (Int32 i = 0; i < this.LComments.Count; i++) {
                sb.AppendLine(this.LComments[i].Text);
            }
            return sb.ToString();
        }
    }
}
