namespace Chat.Entitys {
    internal class Comments {
        private String _text = String.Empty;

        public String Text {
            get => this._text; set => this._text = value;
        }

        public Comments(String txt) {
            this.Text = txt;
        }
    }
}
