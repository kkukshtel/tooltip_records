using static tooltip_records.Tooltips;

bool value = false;
(BaseTooltip with {
    header = "my new tooltip",
    elements = new() {
        value ? SmallImage : BodyText with { text = "alt text"},
        BodyText with { text = "somebody text"},
        SmallImage with { path = "another/image/path" }
    }
}).BuildKDL();
