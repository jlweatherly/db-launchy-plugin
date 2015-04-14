This plugin will allow you to return results from a database to be launched through the Launchy tool.

Configure it with your SQL server credentials, and give it a stored procedure to run.  It will then pull down the results and include them in the catalog for normal launchy use.

## REQUIRES ##
  * [Launchy 2.5](http://www.launchy.net/)
  * [Launchy# Plugin](http://launchysharp.sourceforge.net/)

## USAGE ##
  1. Install the Launchy# Plugin first, DBLaunchy requires Launchy# to work.
  1. Copy DBLaunchyPlugin.dll into the plugins directory (`C:\Program Files\Launchy\plugins` on my machine)
  1. Restart Launchy.
  1. Set the SQL Options for DBLaunchy in the plugin options panel.
    * Currently only supports a single stored procedure (the name is configurable) for returning results.
    * The results should have three columns, `cTitle`, `cDirectory` and `cProgram`.
    * `cTitle` is what is matched to the user input in Launchy.
    * `cDirectory` and `cProgram` get combined to form the command that is ran.