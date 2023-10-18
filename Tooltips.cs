namespace tooltip_records;

using System.Text;
public class Tooltips
{
    public record Tooltip(string header, List<TooltipElement> elements = null)
    {
        public void Build()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<start>");
            foreach (var e in elements)
            {
                e.Build(sb);
            }
            sb.Append("<end>");
            Console.WriteLine(sb);
        }

        public void BuildKDL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tooltip {\n");
            sb.Append($"header '{header}'\n");
            sb.Append("contents {\n");
            foreach (var e in elements)
            {
                e.BuildKDL(sb);
            }
            sb.Append("}\n");
            sb.Append("}");
            Console.WriteLine(sb);
        }
    }

    public abstract record TooltipElement()
    {
        public abstract void Build(StringBuilder sb);
        public abstract void BuildKDL(StringBuilder sb);
    }

    public record Image(string path) : TooltipElement
    {
        public override void Build(StringBuilder sb) => sb.Append($"<image>'{path}'</image>\n");
        public override void BuildKDL(StringBuilder sb) => sb.Append($"image '{path}'\n");
    }
    public record Text(string text) : TooltipElement
    {
        public override void Build(StringBuilder sb) => sb.Append($"<text>'{text}'</text>\n");
        public override void BuildKDL(StringBuilder sb) => sb.Append($"text '{text}'\n");
    }

    public static Tooltip BaseTooltip = new ("Header");
    public static Image SmallImage = new ("image/path/here");
    public static Text BodyText = new ("body text");
}