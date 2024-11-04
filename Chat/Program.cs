using Chat.Entitys;

internal class Program {
    private static void Main(String[] args) {
        Console.Write("Title >> ");
        String title = Console.ReadLine() ?? "No Title!";
        Console.Write("about >> ");
        String about = Console.ReadLine() ?? "No About";
        Console.Write("likes >> ");
        Int32 likes = Int32.Parse(Console.ReadLine() ?? "1");

        Post post = new Post(DateTime.Now, title, about, likes);
        post.AddCommits(new Comments("frist comment"));
        post.AddCommits(new Comments("second comment"));
        post.AddCommits(new Comments("terceiro comment"));

        Console.WriteLine(post.ToString());
    }
}