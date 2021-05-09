ÎH
bE:\SoftProjects\StockAnalyse\StockAnalyse\StockAnalyseCommonClass\ObservableCollectionExtension.cs
	namespace 	#
StockAnalyseCommonClass
 !
{		 
public 

class %
ObservableRangeCollection *
<* +
T+ ,
>, -
:. / 
ObservableCollection0 D
<D E
TE F
>F G
{ 
public 
void 
AddRange 
( 
IEnumerable (
<( )
T) *
>* +

collection, 6
,6 7
bool8 <

needUpdate= G
=H I
trueJ N
)N O
{ 	
if 
( 

collection 
== 
null "
)" #
throw$ )
new* -!
ArgumentNullException. C
(C D
$strD P
)P Q
;Q R
foreach 
( 
var 
i 
in 

collection (
)( )
Items* /
./ 0
Add0 3
(3 4
i4 5
)5 6
;6 7
if 
( 

needUpdate 
) 
OnCollectionChanged #
(# $
new$ ',
 NotifyCollectionChangedEventArgs( H
(H I)
NotifyCollectionChangedActionI f
.f g
Resetg l
)l m
)m n
;n o
} 	
public 
void 
RemoveRange 
(  
IEnumerable  +
<+ ,
T, -
>- .

collection/ 9
,9 :
bool; ?

needUpdate@ J
=K L
trueM Q
)Q R
{   	
if!! 
(!! 

collection!! 
==!! 
null!! "
)!!" #
throw!!$ )
new!!* -!
ArgumentNullException!!. C
(!!C D
$str!!D P
)!!P Q
;!!Q R
foreach## 
(## 
var## 
i## 
in## 

collection## (
)##( )
Items##* /
.##/ 0
Remove##0 6
(##6 7
i##7 8
)##8 9
;##9 :
if$$ 
($$ 

needUpdate$$ 
)$$ 
OnCollectionChanged%% #
(%%# $
new%%$ ',
 NotifyCollectionChangedEventArgs%%( H
(%%H I)
NotifyCollectionChangedAction%%I f
.%%f g
Reset%%g l
)%%l m
)%%m n
;%%n o
}&& 	
public(( 
void(( 
UpdateRowIndex(( "
(((" #
)((# $
{)) 	
try** 
{++ 
var,, 
type,, 
=,, 
typeof,, !
(,,! "
T,," #
),,# $
;,,$ %
var-- 
pr-- 
=-- 
type-- 
.-- 
GetProperty-- )
(--) *
$str--* 4
)--4 5
;--5 6
foreach.. 
(.. 
var.. 
item.. !
in.." $
Items..% *
)..* +
{// 
pr00 
.00 
SetValue00 
(00  
item00  $
,00$ %
(00& '
Items00' ,
.00, -
IndexOf00- 4
(004 5
item005 9
)009 :
+00; <
$num00= >
)00> ?
,00? @
null00A E
)00E F
;00F G
}11 
this22 
.22 
UpdateSource22 !
(22! "
)22" #
;22# $
}33 
catch44 
{44 
}44 
}55 	
public99 
void99 
Replace99 
(99 
T99 
item99 "
)99" #
{:: 	
ReplaceRange;; 
(;; 
new;; 
T;; 
[;; 
];;  
{;;! "
item;;# '
};;( )
);;) *
;;;* +
}<< 	
publicAA 
voidAA 
ReplaceRangeAA  
(AA  !
IEnumerableAA! ,
<AA, -
TAA- .
>AA. /

collectionAA0 :
,AA: ;
boolAA< @

needUpdateAAA K
=AAL M
trueAAN R
)AAR S
{BB 	
ifCC 
(CC 

collectionCC 
==CC 
nullCC "
)CC" #
throwCC$ )
newCC* -!
ArgumentNullExceptionCC. C
(CCC D
$strCCD P
)CCP Q
;CCQ R
ItemsEE 
.EE 
ClearEE 
(EE 
)EE 
;EE 
foreachFF 
(FF 
varFF 
iFF 
inFF 

collectionFF (
)FF( )
ItemsFF* /
.FF/ 0
AddFF0 3
(FF3 4
iFF4 5
)FF5 6
;FF6 7
ifGG 
(GG 

needUpdateGG 
)GG 
OnCollectionChangedHH #
(HH# $
newHH$ ',
 NotifyCollectionChangedEventArgsHH( H
(HHH I)
NotifyCollectionChangedActionHHI f
.HHf g
ResetHHg l
)HHl m
)HHm n
;HHn o
}II 	
publicLL 
voidLL 
RemoveAtLL 
(LL 
intLL  
indexLL! &
,LL& '
boolLL( ,

needUpdateLL- 7
)LL7 8
{MM 	
ItemsNN 
.NN 
RemoveAtNN 
(NN 
indexNN  
)NN  !
;NN! "
ifOO 
(OO 

needUpdateOO 
)OO 
OnCollectionChangedPP #
(PP# $
newPP$ ',
 NotifyCollectionChangedEventArgsPP( H
(PPH I)
NotifyCollectionChangedActionPPI f
.PPf g
ResetPPg l
)PPl m
)PPm n
;PPn o
}QQ 	
publicSS 
voidSS 
UpdateSourceSS  
(SS  !
)SS! "
{TT 	
OnCollectionChangedUU 
(UU  
newUU  #,
 NotifyCollectionChangedEventArgsUU$ D
(UUD E)
NotifyCollectionChangedActionUUE b
.UUb c
ResetUUc h
)UUh i
)UUi j
;UUj k
}VV 	
publicXX 
voidXX 
ClearXX 
(XX 
boolXX 

needUpdateXX )
)XX) *
{YY 	
ItemsZZ 
.ZZ 
ClearZZ 
(ZZ 
)ZZ 
;ZZ 
if[[ 
([[ 

needUpdate[[ 
)[[ 
OnCollectionChanged\\ #
(\\# $
new\\$ ',
 NotifyCollectionChangedEventArgs\\( H
(\\H I)
NotifyCollectionChangedAction\\I f
.\\f g
Reset\\g l
)\\l m
)\\m n
;\\n o
}]] 	
publicbb %
ObservableRangeCollectionbb (
(bb( )
)bb) *
:cc 
basecc 
(cc 
)cc 
{cc 
}cc 
publicjj %
ObservableRangeCollectionjj (
(jj( )
IEnumerablejj) 4
<jj4 5
Tjj5 6
>jj6 7

collectionjj8 B
)jjB C
:kk 
basekk 
(kk 

collectionkk 
)kk 
{kk  
}kk! "
}ll 
publicrr 

staticrr 
classrr )
ObservableCollectionExtensionrr 5
{ss 
public
•• 
static
•• '
ObservableRangeCollection
•• /
<
••/ 0
TSource
••0 7
>
••7 8
	OrderByEx
••9 B
<
••B C
TSource
••C J
,
••J K
TKey
••L P
>
••P Q
(
••Q R
this
••R V'
ObservableRangeCollection
••W p
<
••p q
TSource
••q x
>
••x y
source••z Ä
,
¶¶ 
Func
¶¶ 
<
¶¶ 
TSource
¶¶ 
,
¶¶ 
TKey
¶¶  
>
¶¶  !
keySelector
¶¶" -
,
¶¶- .
bool
¶¶/ 3
	orderyAsc
¶¶4 =
=
¶¶> ?
true
¶¶@ D
,
¶¶D E
bool
¶¶F J

needUpdate
¶¶K U
=
¶¶V W
true
¶¶X \
)
¶¶\ ]
{
ßß 	
List
»» 
<
»» 
TSource
»» 
>
»» 
	sortedLst
»» #
=
»»$ %
null
»»& *
;
»»* +
if
…… 
(
…… 
	orderyAsc
…… 
)
…… 
	sortedLst
   
=
   
source
   "
.
  " #
OrderBy
  # *
(
  * +
keySelector
  + 6
)
  6 7
.
  7 8
ToList
  8 >
(
  > ?
)
  ? @
;
  @ A
else
ÀÀ 
	sortedLst
ÃÃ 
=
ÃÃ 
source
ÃÃ "
.
ÃÃ" #
OrderByDescending
ÃÃ# 4
(
ÃÃ4 5
keySelector
ÃÃ5 @
)
ÃÃ@ A
.
ÃÃA B
ToList
ÃÃB H
(
ÃÃH I
)
ÃÃI J
;
ÃÃJ K
source
ŒŒ 
.
ŒŒ 
ReplaceRange
ŒŒ 
(
ŒŒ  
	sortedLst
ŒŒ  )
,
ŒŒ) *

needUpdate
ŒŒ+ 5
)
ŒŒ5 6
;
ŒŒ6 7
return
““ 
source
““ 
;
““ 
}
”” 	
}
‘‘ 
}’’ á
\E:\SoftProjects\StockAnalyse\StockAnalyse\StockAnalyseCommonClass\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 2
)2 3
]3 4
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
$str 4
)4 5
]5 6
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
]$$) *