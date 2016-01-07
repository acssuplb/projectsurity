#ADOBOCODE v1.0 Specifications

##Paggawa ng _file_
".adobo" ang _file extension_ ng adobo code. `\n`, `\r`, o `\n\r` ang pantapos sa bawat linya ng _code_. Sa _function_ na `SIMULA()` magsisimula ang _program_ at ito ay magtatapos kapag nakakita ng `WAKAS` o `IBALIK`. Hindi _case sensitive_ ang mga _keyword_ sa adobo code. Ang _variables_ ay _case sensitive_. Ang _white spaces_ sa simula ng linya ay hindi pinapansin.

##KOMENTO
Ang mga komento ay ang mga bagay na inilalagay sa _code_ na hindi pinapansinin ng _interpreter_. `KOMENTO` ang ginagamit para sa isahang linyang pagkokomento.

_Syntax:_
```
KOMENTO <komento>
```
Ito naman ang _syntax_ para sa mga komentong lalampas sa isang linya:
```
1 MGA KOMENTO:
2     <komento>
3 DULO NG KOMENTO
```
##_Datatypes_
###_Primitive Datatypes_
Ang isang _primitive datatype_ ay ang _datatype_ na hindi binubuo gamit ang iba pang _data type_ at hindi na maaari pang putulin sa mas maliliit na bahagi. Ang mga sumusunod ang limang uri ng primitibong datos:

1. `BILANG` ang representasyon ng mga numerong walang putal. `0` ang kaniyang halaga kapag inihayag nang walang sinabing halaga.

2. `NUMERO` ang representasyon ng mga totoong numero. Ito ay maaaring magkaroon ng _decimal point_. `0` ang kaniyang halaga kapag walang inihayag nang walang sinabing halaga.

3. `SIMBOLO` ang representasyon ng iba't ibang simbolo at letra. Kapag magdedeklara ng halaga ng `SIMBOLO` ito ay dapat pinagigitnaan ng mga kudlit ('') kung hindi ito ay magbibigay ng _error_. Maglalabas ng _warning_ kapag nagbigay ng halaga ng `BILANG` sa isang `SIMBOLO`. Puwang (_space_) ang halaga kapag walang halagang inihayag pagkatapos ito ideklara. _ASCII character set_ ang gagamitin para magawang `SIMBOLO` ang isang `BILANG`.

4. `SALITA` ang representasyon ng grupo ng `SIMBOLO`. Kapag magdedeklara ng halaga ng `SIMBOLO` ito ay dapat pinagigitnaan ng mga panipi ("") kung hindi ito ay magbibigay ng _error_.

5. `SAGOT` ang representasyon sa mga kondisyon. Ito ay maaari lamang maglaman ng dalawang halaga, `TAMA` o `MALI`. Ang halaga nito kung walang inilagay ay `TAMA`.

##Pangunahing _Function_ (_Main Function_)
Ang pangunahing _function_ ay ang natatanging _function_ kung saan ito ang hinahanap ng _interpreter_ upang patakbuhin kaagad ang lahat ng _command_ dito.

_Syntax:_
```
1 SIMULA()
2    <grupo ng mga gawain>
3 WAKAS
```
Ang `IBALIK` ay maaari ring magpatigil sa pagtakbo ng `SIMULA()`.


##_Variables_
###Primitibong Datos
1.`BILANG`
Ito ang nagsisilbing representasyon ng mga numerong walang bahagi o _whole numbers_. Ang halaga nito kung walang inilagay na halaga pagkatapos ihayag ay 0. Tatlumpu’t dalawang _bits_ ang kayang suportahan nito. Samakatuwid, tatanggapin nito ang mga bilang mula -2147483647 hanggang 2147483647.
Ang ilalagay lamang sa primitibong datos na ito ay ang kabuuan ng isang bilang. Samakatuwid, aalisin nito ang parteng may bahagi. Maglalabas ng babala sa _console_ ang pagsasagawa nito.

Halimbawa:
```
1 BILANG bilang
2 BILANG x NA MAY 2.3		       KOMENTO Maglalaman ang x ng 2
3 BILANG x NA MAY 90000000000	 KOMENTO Maglalabas ito ng error
```

2.`NUMERO`
Ito ang nagsisilbing representasyon ng mga totoong numero o mga bilang na may bahagi. Ang paglalagay dito ng halaga ay hindi kinakailangan ng punto o _decimal point_ ngunit awtomatikong lalagyan ito ng _interpreter_ ng bahaging may 0(_trailing zeroes_). Ang halaga nito kung walang inilagay na halaga ay 0.0000. Hanggang apat na _decimal places_ lamang ang tatanggapin ng _interpreter_. Ang hihigit dito ay puputulin na lamang.

Halimbawa:
```
1 BILANG bilang NA MAY 2277
2 NUMERO numero NA MAY bilang
3
4 KOMENTO Maglalaman ng 2277.0000 ang numero
```

3.`SIMBOLO`
Ito ang nagsisilbing representasyon ng mga iba’t ibang simbolo kabilang ang mga bilang (`0-9`), letra (`A-Z at a-z`), bantas (`?,.”‘:;!`), (_mathematical symbols_ o _operators_) (`+-\*^%[]{}()`), at iba pang mga simbolong matatagpuan sa _keyboard_ (`@#$&_~```|\>/<`). Ang halaga ng isang simbolo ay dapat na pinagigitnaan ng dalawang kudlit. Maaaring magpasa ng halagang mula sa ibang _variable_ ngunit kailangan na ito ay inihayag bilang `SIMBOLO` rin. Ang halaga nito kung walang nilagay na halaga ay `NULL`.

4.`SALITA`
Ito ang nagsisilbing representasyon sa mga grupo ng simbolo kasama na ang puwang at bagong linya. Ang halaga ng `SALITA` ay dapat na pinagigitnaan ng dalawang panipi. Ang halaga nito kung walang inilagay ay blangko o _empty string_.

Halimbawa:
```
1 SALITA salita NA MAY “Isa kang dukha!”
2 SIMBOLO simbolo NA MAY ‘A’
3
4 SIMBOLO a NA MAY simbolo
5 SIMBOLO s NA MAY salita
6
7 MGA KOMENTO:
8         Maglalaman ng “Isa kang dukha!” ang variable na salita
9         Maglalaman ng ‘A’ ang variable na a
10        Maglalabas ng error sa s
11 DULO NG KOMENTO
```

5.`SAGOT`
Ito ang nagsisilbing representasyon sa mga kondisyon. Ito ay maaari lamang maglaman ng dalawang halaga, `TAMA` o `MALI`. Ang halaga nito kung walang nilagay ay `TAMA`.

Halimbawa:
```
1 SAGOT sagot_1 NA MAY MALI
2 SAGOT sagot_2
3
4 MGA KOMENTO:
5        Maglalaman ang sagot_1 ng MALI
6         Maglalaman ang sagot_2 ng TAMA
7 DULO NG KOMENTO
```

###Koleksyon
Ang `KOLEKSYON` ay maaaring maglaman ng maraming halaga ngunit ito ay dapat iisang uri lamang ng primitibong datos. Ang paglalagay at pagtanggal ng halaga ay laging ginagawa sa dulo ng isang koleksyon. Ang mga koleksyon ay may mga _functions_ na maaaring gamitin:

1. `LAGAY (<koleksyon>, <halaga>)`
Ito ay ginagamit upang makapaglagay ng isang bagay sa koleksyon. Hinahanap nito ang dulo ng koleksyon upang paglagyan ng halagang nais idagdag. Magbabalik ito ng halagang `TAMA` kung nailagay niya nang tama ang halagang nais idagdag sa koleksyon.

2. `TANGGAL (<koleksyon>)`
Ito ay ginagamit upang tanggalin ang huling inilagay o kakalagay pa lamang na isang bagay sa koleksyon. Ibabalik nito ang halagang tinanggal. Kinakailangang parehas ang uri ng datos na tinanggal sa paglalagyan nito. Magbibigay ito ng _error_ maliban na lamang sa `BILANG` at `NUMERO`.
Kung `NUMERO` ang ilalagay sa `BILANG`, kukunin lamang nito ang buong bahagi. Kung `BILANG` naman ang ilalagay sa `NUMERO`, ilalagay nito ang halaga at lalagyan ng bahagi na may 0 (_trailing zeroes_). Ang dalawang operasyong ito ay magbibigay ng babala.

3. `KUHA (<koleksyon>, <bilang>)`
Ito ay ginagamit upang kumuha ng isang bagay sa koleksyon. Kinukuha nito ang halagang nasa ika-`<bilang>` na posisyon. Kapag ang bilang ay sumobra sa kabuuang bilang ng mga halaga sa koleksyon, ito ay magbabalik ng halagang `MALI` at magbibigay ng _error_.

4. `PALIT (<koleksyon>, <bilang>, <halaga>)`
Ito ay ginagamit upang palitan ang halaga ng isang bagay sa koleksyon. Ang bagay na nasa ika-`<bilang>` ng koleksyon ay papalitan ng <halaga>. Magbabalik ito ng halagang `TAMA` kung napalitan nang tama ang halaga ng bagay na nasa koleksyon.

5. `HANAP (<koleksyon>, <halaga>)`
Ito ay ginagamit upang hanapin ang isang bagay sa koleksyon. Kung natagpuan ang halagang hinahanap sa koleksyon, ibabalik nito ang posisyon o _index_ kung saan unang nakita ang <halaga> sa koleksyon. Magbabalik naman ito ng halagang `MALI` kung hindi natagpuan ang halagang hinahanap sa koleksyon.

6. `ILAN (<KOLEKSYON na variable>)` 
Ibabalik nito ang bilang ng mga `<halaga>` sa `KOLEKSYON`.


####Iba’t ibang _functions_ sa SALITA
Ang `SALITA` ay isang primitibong uri ng datos ngunit may _functions_ din na ginawa para sa `SALITA` tulad lamang din ng `KOLEKSYON`. Ito ay ang mga sumusunod:

1. `DUGSONG (<SALITA na variable1>, <SALITA na variable2>)`
Pagsasamahin nito ang dalawang `SALITA`. Magsisimula ang `<SALITA na variable2>` sa dulo ng `<SALITA na variable1>`.

2. `HATIIN(<SALITA na variable>, <SIMBOLO na variable>)`
Hahatiin nito ang isang `SALITA` upang makagawa ng `KOLEKSYON NG SIMBOLO`. Gagamitin nito ang `SIMBOLO` upang hatiin ang `SALITA`.

Halimbawa:
```
1 SALITA word NA MAY “kakarampot” 
2 HATIIN(word, “”)         KOMENTO  magbabalik ng  [“k”, “a”, “k” ...] 
3 HATIIN(word, “r”)        KOMENTO  magbabalik ng [“kaka”, “ampot”] 
```

3. `BUUIN (<KOLEKSYON NG SALITA na variable>)`
Bubuuin nito ang `SALITA` gamit ang magkakahiwalay na `SIMBOLO` sa `KOLEKSYON NG SIMBOLO`.


###Pagpapangalan ng _variable_
Sa pagpangalan ng _variable_, ito ay dapat magsimula sa letra o sa salungguhitan. Pagkatapos, ito ay susundan ng letra, numero, salungguhitan, o gitling.

###Pagpapahayag ng _variable_ (_variable declaration_)

Kailangan munang ihayag ang isang _variable_ bago ito magamit. Para makapagpahayag ng isang _variable_, kailangang tukuyin muna kung ano ang uri ng datos.

_Syntax:_
```
<uri ng datos> <pangalan ng variable> [NA MAY <halaga>]
```

Sa `KOLEKSYON`, bahagyang naiiba ang _syntax_ para magpahayag ng _variable_. Ito ay sisimulan sa `KOLEKSYON` at susundan ng `NG <uri ng datos>` na magpapatakda ng uri ng datos na pwedeng ilagay lang sa loob ng `KOLEKSYON`. Kapag ibang uri ng datos ang nilagay sa `KOLEKSYON`, ito ay magbabalik ng _error_.

_Syntax_ sa paghayag ng `KOLEKSYON`:
```
KOLEKSYON NG <uri ng datos> <pangalan ng variable> [NA MAY <halaga1>, <halaga2>, ..., <halagaN>]
```

Ang halimbawa ng pagpapahayag ng `​KOLEKSYON` na may halaga:
```
1 KOLEKSYON NG SALITA bayong NA MAY “isda” 
2 KOLEKSYON NG SALITA bayong NA MAY “isda”, “baka” 
3 KOLEKSYON NG SALITA bayong NA MAY “isda”, “baboy”, “baka”, “kabayo” 
```

Ang kuwit (,) ay hindi kailangang may puwang bago makita ang kuwit o pagkatapos makita ang kuwit.  //_mindblown huhubels help_

Ang halimbawa sa ibaba ay nagpapahayag ng _variable_ na walang idineklarang halaga.
```
BILANG y
```

Ang halimbawa sa ibaba ay nagpapahayag ng _variable_ na may halagang 5.
```
BILANG x NA MAY 5
```

###Mga Operasyon sa Mga _VARIABLES_

1. Palatuusan (_Arithmetics_)
Kailangan ang `ANG RESULTA NG` bago ipahayag ang mga palatuusan na gagawin, kung saan ang salitang `​ANG` ay opsyonal na ilagay. Ang mga palatuusan na gagamitin ay parehas lamang sa kanilang katumbas nilang simbolo. `+` sa pagdadagdag, `-` sa pagbabawas, `/` sa mala-matematikong paghahati, `//` sa mala-bilang na paghahati, at `*` sa pagdarami. _Caret_(`^`) naman ang gagamitin para sa _exponentiation_. Hindi susuportahan ng ADOBO CODE ang pagkuha ng _modulo_.

_Syntax_:
```
[ANG] RESULTA NG <matematikong ekspresiyon>
```

Ang mala-matematikong paghahati(/) ay maglalabas ng `NUMERO` kahit hindi `NUMERO` ang nasa panakda at pamanagi. Ang mala-bilang na paghahati (//) ay palaging maglalabas ng `BILANG` ngunit dapat na walang putal ang mga halaga sa panakda at pamanagi kung hindi ito ay maglalabas ng _error_. Parehas silang maglalabas ng _run-time error_ kapag naging 0 ang pamanagi.


2. Paghahambing (_Comparison_)
`AY MAS MALAKI SA` ang magsasabi kung ang halaga sa kaliwa ay mas malaki sa halaga na nasa kanan. `AY MAS MALIIT SA` ang magsasabi kung ang halaga sa kanan ay mas malaki sa halaga sa kaliwa. `AY PAREHO SA` ang magsasabi kung pantay lamang ang mga _operand_ sa kaliwa at sa kanan.

Kapag `SIMBOLO` o `SALITA` ang inihahambing, titingnan nito ang alpabetikong pag-aayos ng mga simbolo. Mas malaki ang halaga kapag mas malapit sa `Z` at mas maliit ang halaga kapag mas malapit sa `A`.

3. Pag-uugnay ng mga pinaghahambing (_Logical_)
Upang maipagsama ang mga pinaghahambing sa isang utos, maaaring gumamit ng mga pang-ugnay ng mga pinaghahambing. `AT` ang magsasabi kung ang mga kundisyon ay parehas na `TAMA` at kung hindi ito ay magbabalik ng `MALI`. `O` ang magsasabi kung kahit isa sa mga kundisyon ay `TAMA` at kung hindi ito ay magbabalik ng `MALI`.



##PAGLILIMBAG AT PAGKUHA NG IMPORMASYON
###Paglalabas o Paglilimbag ng _Data_
Upang maglimbag o maglabas ng mga salita o mga `<halaga>` sa _console_, gagamitin ang mga salitang `ISULAT ANG` kung saan ang `ANG` ay opsyonal na inilalagay sa kowd ngunit kapag nilagyan ng `NANG WALANG TIGIL` kaysa sa `ANG` lamang, tatanggalin na nito ang bagong linya sa dulo.

_Syntax_:
```
ISULAT [ANG | NANG WALANG TIGIL] [<halaga1>,<halaga2>, ...][PUTULIN]
```

Halimbawa:
```
1 ISULAT ANG “Kamusta ka?” 
2 ISULAT “Ayos lang!” 
3 MGA KOMENTO: 
4      Isusulat nito ay: 
5 	   Kamusta ka? 
6 	   Ayos lang! 
7 DULO NG KOMENTO 
8 
9  ISULAT NANG WALANG TIGIL “Ang aking grade: “ 
10 ISULAT 54/100 
11 MGA KOMENTO: 
12     Isusulat nito ay: 
13 	   Ang aking grade: 54/100 
14 DULO NG KOMENTO
```

Kung `KOLEKSYON` ang inilagay sa `<halaga>`, ipapakita nito lahat ng `<halaga>` na hinahawakan ng isang `KOLEKSYON`.

Ang isang halimbawa nito ay kapag may ganitong `KOLEKSYON`:
```
KOLEKSYON NG SALITA miyembro NA MAY “Miles”, “Aron”, “PJ”
```

At ginawa ito:
```
ISULAT ANG miyembro 
```

Ang ilalabas nito sa _console_ ay ang mga sumusunod:
```
[“Miles”, “Aron”, “PJ”]
```

###Escape Characters
Upang makapaglabas ng mga simbolo na naireserba na sa ibang ginagawa, gagamitin ang _backslash(\)_ para dito. `\linya` ang gagamitin upang maglabas ng bagong linya. Ito ang halimbawa ng pagkakagamit ng _escape characters_:
```
1 ISULAT ANG “Ang pangalan ko ay", pangalan, “.\linya”
2 ISULAT ANG "Maaari ninyo akong tawaging \" ", palayaw, " \". "
```

###Pagpapasok o Pagkukuha ng _Data_
Upang humingi ng halaga galing sa taong gumagamit, gagamitin ang mga salitang `HINGI NG` kung saan ang salitang `NG` ay opsyonal lamang na ilagay sa kowd.

_Syntax:_
```
HINGI [NG] <pangalan ng variable> 
```

Hindi maaaring `KOLEKSYON` na _variable_ ang ilalagay sa `HINGI NG`. Kailangan muna itong ilagay sa ibang _variable_ saka lang gagamitin ang `LAGAY` o `KUHA` ng `KOLEKSYON` para makapaglagay ng halaga gamit ang `HINGI NG`.

Halimbawa:
```
1 BILANG x NA MAY 5 
2 KOLEKSYON NG BILANG data 
3 HINGI NG data 		KOMENTO hindi pwede ito 
4 HINGI NG x 
5 LAGAY(data, x)		KOMENTO pwede ito
```


##KUNDISYON
Upang gumawa ng mga utos na may kundisyon, kailangang gamitin ang `KUNG`, `O KUNG`, at `KUNG HINDI`.

_Syntax:_
```
1 KUNG <pinaghahambing> 
2      <grupo ng gawain> 
3 [O KUNG <pinaghahambing> 
4     	<grupo ng gawain> 
5 [O KUNG <pinaghahambing> 
6 	    <grupo ng gawain> 
7 ...] 
8 [KUNG HINDI 
9 	    <grupo ng gawain>] 
10 DULO NG KUNG 
```

Sa pagtingin sa kung anong grupo ng gawain ang papasukan, titingnan nito ang `<pinaghahambing>` sa `KUNG`. Kapag ito ay `TAMA`, papasok ito sa mga `<grupo ng gawain>` sa loob ng `KUNG`. Kapag `MALI` ang `<pinaghahambing>` ng `KUNG`, saka lang ito papasok sa susunod na `O KUNG`, kung mayroon mang maging `TAMA`. Ganoon ulit ang proseso, titingnan lamang niya kung `TAMA` ang `<pinaghahambing>` sa `O KUNG`at kung `TAMA`, ito ay papasok sa `<grupo ng gawain>` nito.
Kapag lahat ng `<pinaghahambing>` sa `KUNG` at `O KUNG` ay `MALI`, saka lang ito papasok sa mga `<grupo ng utos>` sa loob ng `KUNG HINDI`.


##MGA IKOT
Ang ikot ay ang pa-ulit ulit na pagsasagawa ng mga gawain. Ito ay may tatlong parte: kung saan magsisimula `<pagpapahayag>`, kung hanggang kailan ito tatakbo `<kundisyon>`, at kung anong pagbabago ang mangyayari `<pagbabago>`. `HABANG` naman ang gagamitin para makapagpahayag ng ikot.

_Syntax:_
```
1 HABANG 
2 	    <pagpapahayag> 
3 	    <kundisyon> 
4 	    <pagbabago> 
5 GAWIN 
6 	    <grupo ng utos> 
7 DULO NG HABANG 
```

Dapat ang mga ipinahayag nga _variable/s_ ay hindi pa dapat naipapahayag. Ang mga naipahayag na _variables_ sa `<pagpapahayag>` ay hindi maaaring gamitin sa ibang parte ng palatuntunan.

Ang halimbawa ng `HABANG` na gumagamit ng isang _variable_ sa ikot:
```
1 HABANG 
2 	    BILANG i NA MAY 0 
3 	    i AY MAS MALIIT SA 10 
4 	    ILAGAY SA i ANG RESULTA NG i+1 
5 GAWIN 
6 	    ISULAT ANG i 
7 DULO NG HABANG 
```

Ang halimbawa ng `HABANG` na gumagamit ng dalawang _variable_ sa ikot:
```
1 HABANG 
2 	    BILANG i NA MAY 0, BILANG j NA MAY 0 
3	     i AY MAS MALIIT SA 10 
4	     ILAGAY SA i ANG RESULTA NG i+1, ILAGAY SA j ANG RESULTA NG j+2 
5 GAWIN 
6 	    ISULAT ANG i, “ “, j 
7 DULO NG HABANG 
```

Para naman sa hindi matapos na pag-iikot ito ang gagamiting na palaugnayan:
```
1 HABANG 
2 GAWIN 
3 	    <grupo ng utos> 
4 DULO NG HABANG
```
Maaaring gamitin ang `TIGIL` na _keyword_ upang pigilan ang ikot kahit na `TAMA` pa ang kundisyon. Maaari namang gamitin ang `TULOY` para laktawan ang mga utos at pumunta kaagad sa susunod na ikot. Ngunit tandaan na ito ay dadaan sa `<pagbabago>` ​bago magsimula ang susunod na ikot.


##MGA _FUNCTIONS_
###Paggawa ng _Functions_
Ang _function_ ay grupo ng mga gawain na maaring gawin o ipahayag nang isahan upang hindi ito magpaulit-ulit sa kowd. Ang kailangan upang makagawa ng isang _function_ ay ang pangalan ng _function_ at ang listahan ng mga parametro nito. Ito ay tinatapos lagi ng `WAKAS`.

_Syntax:_
```
1 <pangalan ng ginagawa>([<paramtero1>, <parametro2>, ...]) 
2 	     <grupo ng mga gawain> 
3 WAKAS 
```

Sa pagpapangalan ng ginagawa, ito ay maaaring simulan sa letra o sa salungguhitian(_). Pagkatapos, pwede itong sundan ng letra, numero, salungguhitan, o gitling(-) ngunit hindi maaari ang salitang `SIMULA` sapagkat ito ay nakareserba na para sa pangunahing ginagawa.

Upang tawagin ang isang ginagawa, gagamitin natin ang `TAWAGIN ANG`. Ipinapahayag nito na magtatawag tayo ng isang _function_.

_Syntax:_
```
TAWAGIN ANG <pangalan ng ginagawa> ([<argumento1>, <argumento2>,...])
```
Ang mga ginagawa ay maaari ring magbalik ng halaga pagkatapos gawin ang mga utos. Kumbaga, ito ang papalit na halaga sa kaniya kapag tinawag. Upang makapagbalik ng halaga, gagamitin ang salitang `IBALIK`.

_Syntax:_
```
IBALIK [ANG] <halaga> 
```

Ang `ANG` ay maaari nang hindi ilagay. Kapag nakita na ang `IBALIK`, hindi na patatakbuhin ang ibang utos dahil bumalik na siya sa isang ginagawa na tinawag bago ito.

Ito ang halimbawa ng paggawa ng _function_:
```
1 SIMULA() 
2     BILANG A NA MAY idagdag(5, 3) 
3 	   ISULAT ANG A 
4 WAKAS
5
6 idagdag(BILANG X, BILANG Y) 
7     IBALIK ANG RESULTA NG X+Y 
8 WAKAS 
```

Ang kowd sa taas ay magpapakita ng `8` sapagkat ang tinawag ng `SIMULA` ang `idagdag` na may argumentong `5` at `3`. Pagkapasa ng 5 at 3 sa `idagdag`, ang `X` ay kinuha ang halagang 5 at ang `Y` ay kinuha ang halagang 3. Pagkatapos, pinagsama ang halaga ng `X` at `Y` at ibinalik ang resulta. Kaya ang nailagay na halaga kay `A` ay 8. At sa huli, isinulat ang `A` sa _terminal_ kaya ito ay nagpakita ng `8`.

Tandaan na ang mga _functions_ ay dapat na ilagay pagkatapos ng `SIMULA`. Ito ay magbibigay ng _error_ kung hindi ito nasunod.
