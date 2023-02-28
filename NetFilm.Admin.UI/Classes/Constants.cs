namespace NetFilm.Admin.UI.Classes
{
    // defined routes for navigation
    public static class Routes
    {
        public static string Films => "Films";
        public static string Directors => "Directors";
        public static string Genres => "Genres";
        
    }

    //defined navigation types used for buttons
    public static class PageType
    {
        public static string Index => "Index";
        public static string Create => "Create";
        public static string Edit => "Edit";
        public static string Delete => "Delete";
        public static string AddGenre => "Add Genre";
        public static string AddSimilar => "Add Similar Film";
    }
}
