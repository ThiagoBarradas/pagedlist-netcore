[![Build status](https://ci.appveyor.com/api/projects/status/ljmbe0qjtiy7ixx7/branch/master?svg=true)](https://ci.appveyor.com/project/ThiagoBarradas/pagedlist-netcore/branch/master)
[![codecov](https://codecov.io/gh/ThiagoBarradas/pagedlist-netcore/branch/master/graph/badge.svg)](https://codecov.io/gh/ThiagoBarradas/pagedlist-netcore)
[![NuGet Downloads](https://img.shields.io/nuget/dt/PagedList.NetCore.svg)](https://www.nuget.org/packages/PagedList.NetCore/)
[![NuGet Version](https://img.shields.io/nuget/v/PagedList.NetCore.svg)](https://www.nuget.org/packages/PagedList.NetCore/)

# PagedList 

Paged list for .NET applications

# Utilization with basic navigation

## Create new pagination object 

```csharp

string originUrl = "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=5";

int itemCount = 347;

int pageSize = 10;

int pageNumber = 5;

PagedList pagedList = new PagedList(originUrl, itemCount, pageNumber, pageSize);

```

## Object structure

```json
{
	"options" : {
		"pageNumber" : 5,
		"pageSize" : 10,
		"itemCount" : 347,
		"pageCount" : 35
	},
	"navigator" : {
		"navigatorSize" : null,
		"first" : {
			"url" : "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=1",
			"number" : 1
		},
		"previous" : {
			"url" : "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=4",
			"number" : 4
		},
		"next" : {
			"url" : "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=6",
			"number" : 6
		},
		"last" : {
			"url" : "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=35",
			"number" : 35
		},
		"numerics" : null
	}
}
```

# Utilization with basic and numeric navigation

## Create new pagination object

```csharp

string originUrl = "http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=5";

int itemCount = 347;

int pageSize = 10;

int pageNumber = 5;

int navigatorSize = 10;

PagedList pagedList = new PagedList(originUrl, itemCount, pageNumber, pageSize, navigatorSize);

```

## Object structure

```json
{  
   "options":{  
      "pageNumber":5,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":10,
      "first":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=1",
         "number":1
      },
      "previous":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=4",
         "number":4
      },
      "next":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123=123&pageSize=10&pageNumber=6",
         "number":6
      },
      "last":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=35",
         "number":35
      },
      "numerics":[  
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=1",
            "number":1
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=2",
            "number":2
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=3",
            "number":3
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=4",
            "number":4
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=5",
            "number":5
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=6",
            "number":6
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=7",
            "number":7
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=8",
            "number":8
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=9",
            "number":9
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=10",
            "number":10
         }
      ]
   }
}
```

# Some response samples

For this examples, the numeric navigator is defined as 3.

## Current page is the first

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=2",
         "number":2
      },
      "last":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=35",
         "number":35
      },
      "numerics":[  
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=1",
            "number":1
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=2",
            "number":2
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=3",
            "number":3
         }
      ]
   }
}
```

## Current page is the last

```json
{  
   "options":{  
      "pageNumber":35,
      "pageSize":10,
      "itemCount":347,
      "pageCount":35
   },
   "navigator":{  
      "navigatorSize":3,
      "first":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=1",
         "number":1
      },
      "previous":{  
         "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=34",
         "number":34
      },
      "next":null,
      "last":null,
      "numerics":[  
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=33",
            "number":33
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=34",
            "number":34
         },
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=35",
            "number":35
         }
      ]
   }
}
```

## One item to show - Single page 

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":10,
      "pageCount":1
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":null,
      "last":null,
      "numerics":[  
         {  
            "url":"http://www.myapp.com/list?filterA=xyz&filterB=123&pageSize=10&pageNumber=1",
            "number":1
         }
      ]
   }
}
```

## Zero items to show

```json
{  
   "options":{  
      "pageNumber":1,
      "pageSize":10,
      "itemCount":0,
      "pageCount":0
   },
   "navigator":{  
      "navigatorSize":3,
      "first":null,
      "previous":null,
      "next":null,
      "last":null,
      "numerics":null
   }
}
```

# How can I contribute?
Please, refer to [CONTRIBUTING](CONTRIBUTING.md)

# Found something strange or need a new feature?
Open a new Issue following our issue template [ISSUE-TEMPLATE](ISSUE-TEMPLATE.md)

# Changelog
See in [nuget version history](https://www.nuget.org/packages/UAUtil)

