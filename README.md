# tooltip_records

thinking about ways to allow for type safe external data authoring that can also be hot reloaded and "compiled"

tooltips are a great expample of this because they need:
* data objects to operate on
* lots of loose files
* very prone to mis configuration

idea is to use something like records in dotnet-script to
* import a type definition API via #r
* built a tooltip with a record type
* at runtime, "compile" that record (basically just ToString()) to some intermediate format
* parse that format and unify the function calling locations to build the tooltip

there's a basic XML style IL, but also thinking about how using something like KDL could be nice?
main thing is just whatever parses faster, an HTML dom/XML/KDL/etc.