�
VE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockStatus\ModuleStockStatusModule.cs
	namespace 	
ModuleStockStatus
 
{ 
public

class
ModuleStockStatusModule
:
IModule
{ 
public 
void 

(! "
IContainerProvider" 4
containerProvider5 F
)F G
{ 	
var 

= 
containerProvider  1
.1 2
Resolve2 9
<9 :
IRegionManager: H
>H I
(I J
)J K
;K L

. "
RegisterViewWithRegion 0
(0 1
$str1 B
,B C
typeofD J
(J K
	StatusbarK T
)T U
)U V
;V W
} 	
public 
void 

(! "
IContainerRegistry" 4
containerRegistry5 F
)F G
{ 	
} 	
} 
} �
VE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockStatus\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 


( 
$str ,
), -
]- .
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
$str .
). /
]/ 0
[
assembly
:

AssemblyCopyright
(
$str
)
]
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
]$$) *�
[E:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockStatus\ViewModel\StatusbarViewModel.cs
	namespace 	
ModuleStockStatus
 
. 
	ViewModel %
{		 
public

 	
class


 
StatusbarViewModel

 "
:

# $
BindableBase

% 1
{ 
public 
StatusbarViewModel !
(! "
)" #
{
} 	
} 
} �
SE:\SoftProjects\StockAnalyse\StockAnalyse\ModuleStockStatus\Views\Statusbar.xaml.cs
	namespace 	
ModuleStockStatus
 
. 
Views !
{ 
public 

partial 
class 
	Statusbar "
:# $
UserControl% 0
{ 
public 
	Statusbar 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} 