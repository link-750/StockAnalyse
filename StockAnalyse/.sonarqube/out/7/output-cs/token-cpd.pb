ì
RE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockTool\ModuleStockToolModule.cs
	namespace 	
ModuleStockTool
 
{ 
public 

class !
ModuleStockToolModule &
:' (
IModule) 0
{ 
public 
void 
OnInitialized !
(! "
IContainerProvider" 4
containerProvider5 F
)F G
{ 	
var 
regionManager 
= 
containerProvider  1
.1 2
Resolve2 9
<9 :
IRegionManager: H
>H I
(I J
)J K
;K L
regionManager 
. "
RegisterViewWithRegion 0
(0 1
$str1 @
,@ A
typeofB H
(H I
ToolBarI P
)P Q
)Q R
;R S
} 	
public 
void 
RegisterTypes !
(! "
IContainerRegistry" 4
containerRegistry5 F
)F G
{ 	
} 	
} 
} ÿ
TE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockTool\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str *
)* +
]+ ,
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str &
)& '
]' (
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str ,
), -
]- .
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 9
)9 :
]: ;
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *Å
WE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockTool\ViewModel\ToolbarViewModel.cs
	namespace		 	
ModuleStockTool		
 
.		 
	ViewModel		 #
{

 
public 	
class
 
ToolbarViewModel  
:! "
BindableBase# /
{ 
public 
ToolbarViewModel  
(  !
)! "
{ 	
} 	
} 
} ‰
OE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockTool\Views\ToolBar.xaml.cs
	namespace 	
ModuleStockTool
 
. 
Views 
{ 
public 

partial 
class 
ToolBar  
:! "
UserControl# .
{ 
public 
ToolBar 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} 