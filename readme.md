# beschdIRCd #
or "best IRC daemon" if you want to.

beschdIRCd is a project by me a german student who doesn't like any irc server out there.
So I decided to write another one. As I'm German I want to use some things from german language. So "beschd" is just another form of english "best" but .. well it has a sarcastic background.

## Why this!? ##
Because I can.

## Requirements ##
This project will require

* Windows Vista+ (Windows Server 2k8)
* .NET Framework 4.5
* SqlCe 4.0 (or if you want SqlServer, or anything which has Entity Framework Support)
* Internet.

## Sources ##
I'm using [RFC 1459](http://tools.ietf.org/html/rfc1459) for basic implementations of IRC protocol.

Trying to convert the RFC via RegEx into some enums. Found a working RegEx-Pattern:

Find: `^\s+(\d{3})\s+ERR_(\w+)\r\s+"(.+)"\r\s+- (.*)`

Replace: `{"Name": "$2", "Value": $1, "Description": "$4", "Remarks": ["$3"], "Results": [], "Command": []},`

Lookup `EnumGenerator` in sources. For formatting you may look into `RFC-1459-ReplyCodes-Modified.txt`.
For comparison go to [this gist](https://gist.github.com/AliveDevil/6672484) which shows the different steps to create an enum.

## Idea behind ##
I want to create a IRC server which is independent of any external service (may be I'll write kind of plugin interface).

## License ##
.. is to be decided.
Will look out for one.

## Contribution ##
You may contribute so I can get forward in development but you're not forced to.
It's for me to get some distance to other projects I'm actively working on. Don't expect fast development.

## End ##
Thath's it. If I can write more .. I'll do.