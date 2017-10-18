namespace AllycsPointRuler
{
    using System.Collections.Generic;

    public static class PointConfigInfo
    {
        public static Dictionary<string, Dictionary<string, PointRuler>> Rulers { get; set; } =
        new Dictionary<string, Dictionary<string, PointRuler>>();
    }
}