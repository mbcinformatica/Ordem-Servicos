-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 192.168.1.198    Database: DBOrdem-Servicos
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `DBProdutos`
--

DROP TABLE IF EXISTS `DBProdutos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DBProdutos` (
  `IDProduto` int NOT NULL AUTO_INCREMENT,
  `IDProdutoInterno` varchar(50) DEFAULT NULL,
  `IDProdutoFabricante` varchar(50) DEFAULT NULL,
  `Descricao` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `IDFornecedor` int DEFAULT NULL,
  `IDMarca` int DEFAULT NULL,
  `IDModelo` int DEFAULT NULL,
  `IDUnidade` int DEFAULT NULL,
  `PrecoCompra` decimal(10,2) DEFAULT NULL,
  `PrecoVenda` decimal(10,2) DEFAULT NULL,
  `EstoqueAtual` decimal(10,4) DEFAULT NULL,
  `EstoqueMinimo` decimal(10,4) DEFAULT NULL,
  `DataUltimaCompra` datetime DEFAULT NULL,
  `Garantia` varchar(50) DEFAULT NULL,
  `Imagem` longblob,
  PRIMARY KEY (`IDProduto`),
  UNIQUE KEY `CodInternoProduto_UNIQUE` (`IDProdutoInterno`),
  UNIQUE KEY `CodProdutoFabricante_UNIQUE` (`IDProdutoFabricante`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DBProdutos`
--

LOCK TABLES `DBProdutos` WRITE;
/*!40000 ALTER TABLE `DBProdutos` DISABLE KEYS */;
INSERT INTO `DBProdutos` VALUES (1,'MBC01','ABC01','CC01',6,3,5,22,550.00,757.00,5.0000,2.0000,'2024-10-14 23:24:30','1 ANO',_binary 'ÿ\Øÿ\à\0JFIF\0\0`\0`\0\0ÿ\Û\0C\0		\n\r\Z\Z $.\' \",#(7),01444\'9=82<.342ÿ\Û\0C			\r\r2!!22222222222222222222222222222222222222222222222222ÿÀ\0\0 \0ˆ\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñð$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rðbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0\Ðj85#ñUÙªŒÉƒT\ÈõG}H²R©•¯¦\Íûô\ç½s±\ÉZZ|Ø¹žõI‰4\Â\â\çUh­Ñœ„RBöúš¿—\Þ5Yc[ø¢S¼Iai<Í˜!±Œþ½hÚ·KGÿ\0¾\ÇøU·.†iC«4WK¼\îcð#NþÊ¹=d‹õ¬\ßøM\à=-ýüÿ\0\ëP|müúÿ\0\ãÿ\0ýjW™_»4E¸oùo\äjðü\çþ^bðT[\ÇQ¯KAÿ\0?ú\ÕN\ïÇ\ád[]¹\ã!ÿ\0ú\Ô{\á\îÕ›#ø\î\ã\éIq¡\\G2\Än\"\Ëc‡½b/Š£ŠFf„¶}Z­_|CŠeÀ±\Ø\Øû\ÂOþµ;\È\É!³\éS¬\Æ/:&`3÷MV›EºYŒFke`¥\ÎK| z\Õ%ñ¬P\É#ˆ\\c–\ÍW»ñ¥´°´qÁ${\Ô+±`K\çÒ•\ä\Ø<;¨_Á$°IlR3†%˜s\éÒŠ‡Lø§\éºtÖm3‰p!‡QyR)NNµid1š‚U¨6+gšpjcqL\ÝHeÄ’®YË‰\×\ëY*ü\â®Y\îiAu~ñ=\0\Ë\ÓZ\rCZºf™‘P\'\ÝœŠ´šL\n9žSùUU\Ô,-.§•\ågiv‚01ZVzÖ6\0¾¥\å?\ÐSsf.œ›#]:\ßþzKùŠ\Z\Â\ÜŸ÷\ÕlEw\á§|³\É\Éûªø\ãWøu\Æ#.Ç¸Á?­.v\Ê]\ÎR[;aüR\ßU2\Ç\æc-·pš\î®|?eq=•\ã+ž‹\'O\ÌVÿ\0„u+X$¸H¾Ò­Œy\';y\êj”…\É%¹ºl÷‹þ\rT/¬m\âVe\Þ\0\èV\ÆZ4†9¬\íIK\Û3.	©\æd]˜÷°$Jû›,8»\ÖaH\Ùñ–\ÆqÖ¬\\\É\'’‹\ÝF85Q1•\'\Ó\ëU\ÌÊ¸\é´ø‚\äI\'\çÚŠ´#‘—•4Q\Ì\Å\Ì\ÍK[¯0g£¯µ£¸KGZ\È\ÖtÛ­Th“”u?,©\íþx55¥Úº«©ù·¥T£ch\Ê\ä²ñU‹b¦»‘Wor\Ç\nsT\çŽTPw\Æ$=®}³Y•r\Ì@\È\ê‚IÀ©5[ß±\Ûýž&\áy\'=[\Ô\Õ}6ðGn÷@VLmPZ\Õ\Ó4Oµ\ÉöË…%[•V­&\ì\\b\äsvºN¡¨ûJ!þ\'\ïøVÝ·†\\žf>¸®¥`D\à\â­G\Ë÷kVGJ£sk¡<x)+‚*eŠúÙ²\0qô®™cpsOû8o\á¡N@\é\Ä\çS#3tn»rNÂ¶,/olÉº¶¼k÷\âcó^;ŠÑŠ\Ùª\Ò\Ém`ñþ\êAÑ€¡É“ÈŠšÕ¥ž¹`×¶ñˆ®\Ñwƒ‰\0\íZó¹n£0ºe¹ÿ\0a¿Â»©L–2¼‘¨	\Ï\Zô>¥k\Öm\åŠð½±‘ “\æ@\Ýõpw\Ð\æ«I^\ç)|°\Ç)\\óû¶ÿ\0\n}³¤hD»\Æ0FPÿ\0…i2^ÿ\0v_Î¢1\ßvOÎ´2p#ûtYÇ˜\×\"ŠVŽÿ\0\ÒOû\êŠv\'Ùž±­\èðk6&	>Y&)1\Ê7øzŠò©\âŸH¿–”(T\âEþL?\ÏJö»‹vû\èpGj\å|Q£Ã«i²\\\0#º¶B\Ùn\ê9 ÿ\0Cÿ\0×®\Ù\Æ\è\æ§>Wc‹.\"ò\ßŠ¨ö\ßhY$Á‰°N{úUý’ùH\Ç1“\é\éZ­°þù\0òMr5fv&kZ\Øý¢\â+||¹\Ü\Õ\Û\ÇX\Â\à\ØV”ªf\ë”\rŸZ–\æiofvHÓŒ#`W<÷;)­45¤’\Þ‰»\Ü\Ò$\èÿ\0q\Æ=sF\Þ\Ñ\\¹9süE‰«–Ž‚U@\Ã\Ð\Ö,\Ý#o\Ì±»¾)\ÞxNL˜¹¦,D\É\Åe_J±’	õ\ÍKeZ\æ\ÂkVªv¼\éøš°—v·GÌ…ú\í\ÝÖ¸\Äki\ßªüôÛš¸[.<µ\nÃœ\r;\Ûry{\×\Ê\Z1•ù”÷®S]i,¬\ÒdPË¸¯?\Ãßšè¢œ\ÏW%Ž8oZ\ç|e:Á\áå“/4Š\ç¦95¥)]˜Ö•\ÎUõ›ŸTÿ\0¾j\Ön¼¿•b¼žõI]\'!¸u{ƒüKùQX;³E0>·k+r¸\Ø\\?Äm§xm„A\Òk—ŒŸ\á\êß ®›\ÃúÔš´R¬ñ\æ‡Šž9\ÇºWšü_Õ·\êöö\nù\Ðoaþ\Óÿ\0õ€ü\ê\ã)^\×3œ`\Õ\Ò<\Ú\Êw¬\Æ\ÜR]±\Ø\n\ÞùR\ÊBC\Èr9\àóý+7Aä¸¸õ\"5þgúU»¹B¬iýÜ·\ëŸ\éFò‡k¥¨m‘ƒ\Ïz€%\ì*\Í\r˜—<ƒ#aWüMih\Ðn…þ\î	@\í\Åiý\Ýö#dž§°®F\î\îz1‹Š\å8V:\Ä\î|×…?u#\'õ5«¥\éÓ‰IG+\è1šÜ¼‚\Ö\Ã\ç/½\Ç$Ÿ\éV\ìŒf\Ó|\à\Ç!Uÿ\0\ZƒT´¹f\Û\Ì^\ë·¹ýgM’Y \äz\Ö\Ò\\²¯ Z•¦7(UßŒ¬Ý‹QgœKa¨Bÿ\0»¹x›<e£mý¦ñªL\"ŸŽ[\îŸÂºH¦†f1\\\Â7)ÁR9©?³\ãOš%?º{P\ÝÐ­fQ\Ó\ÖD}®Ns\\\Ä	[ý0\ãh\ÜJû× ª(^1‘^wñ\Ú\çÌ†\í­¦6¨\n´Ê¹U$ô?\ç½U\r%c*\êñ¹Â»\Ô{³AÃ\Ê\ÙSÞ…P:\×a\Â9h©bM\í€3E1\\õh5‹HÙ’fE’\Ê\Ø\é\ï\í^q\ân}[Sš\îy\ÞR[®\Ð0¿¥h\êÚ„\ËfÑ¼Œ|Ó³ŸA\×ü?\Z\äO6ã“€N>‚©+E¶‘—¦D§‚Wqúžj– \áoUs\ÇOÎ¯·‰´[‹1n^ñ$..Q¸\ÛÀÁ\é\Ås³^\Çó#G;~ñ#Š\å»\á¹Yô9[†e\Ú\Ç\Üq[2\Ý`ù{\Õ-9\â\r\é­šb\È03›õ¨/§+\'Šâ©¤N‹æŠ¹F\âgž\äd\ä)Éªš®©©GqÆ±´l9\ÎIúqÒ¯,.\ÐLu\ÜIšž\ám¡Ó’bmRªz\í\'¿\åN0\ÓPdž†\\Z¼²¢’˜&c«\ßIq‘ùfk/\ãžk\ršI\æ9]œ\æq\å:\Ü\å\È\ì>¾ø\íô©t\Ñ^\Þ]Q\Õ\Þ\È\âQ>9äŠ½iu\æ&s“\ê+š·\Ô%’&/‡p\Ø=¾•§ap…¶¡\ëÚ²”ZF±š‘¼c>Õ•\ã´²ðu\âðòL†0˜\Ï\Þ\Çò­\ãµy÷\Åi\Ù\'\Óa†\âe\Ì-#Ç¸\í#<t\ÏZ¼7\ÅsŸð\Øó…š[c \n=Cv4\Óy>~\êÂ«?˜XœžM3÷ž¦»N#R\Ö\í‹ü\ØF\ìEœ±\ç\ïEP¬v\Ú÷Œ.5h^\ÝbŠR1åªŒU}\'Àú¾¯mö\ã\ZYiÿ\0óõtv«öGVúô÷®\×AðvŸ\áÄŽ\çV5-d¨x\ìU¿¡s\Óñ?€=j·Œ5+‹ñ\Úo\î\æ8þXc‚¯©\ç\éT•\Ì\ïc*\Ù<?\á©V[C6«z%p>Ã¿\ëT¯u\Û\í@4X†d?4qGÁª„g“M\Û\Í_*\ÏcÐ£</g<i\Ã/OÂ³µD&\ÊY9* “\î*¿‚/š}Ú‘ÿ\0\ä\àg¨=«jò’\Í\â<,Ñ•\ê<\×4\á\ï\\\ê§RÑ±\ÅA¨\ß^\ÌÑ«ˆc\rò¾3·\Ð}+at‰LòF-\×n1ùVu¼F	$óA1—\'±\ÅZk€\Ë\æl\ÇVOs¦›I\0\Ó\ZÚ¯O–¡}!Û®ž\Û*Y\íeT%gç¥2T•Yš\Ø\ÆG<}\rD‘º¨ŸB…ÝÍ¢#t\ÜÂ\Ï4hMöØ’@A##ulGx|\çø³Q\Ú\è\æÕ»F\Â1\Ã\ÜOÒ¡j¬\Ìå£º:›NfBzu\Åp­\Ô\Ïm8YP\Æ2>nÇŽ\Øæ»«CŸ0¤‚\rp~4þ‚b‘Q¡m€¶Hu\ïùu­hA£Ÿ4\Ý\Ï.‘ùÿ\0Q\äöSùWR<% \É:…°?\î?ÿ\0Qÿ\0\Â-6\ì\ëP=pÿ\0üMt]w8>±Kù‘\Í|ÿ\0\Ý4WRžŒ­\Ô\â\É\æ(ªÓ¸}bŸsº¾¾!]#-´\Ì\Ìr\Î\Ý\É=\Ír÷\Òy‡Öµ§y.\ßË‚‘@‹šž\Û\ÂW=\Ü\ÉlŸ\Ý;€ü\êÜ”w)A\Ëc”#¥¶²º¼l[[\É\'º¯ñ\é^‡i\á}&\×\r\ä4\î?ŠcŸÓ¥_t\nB¨\èª0\áYÊº\èo\Z©\á«;­5§X¢f\07Í¸?A]`aw\ÂôõÁ¬¹¾VœãŠš\ÚRJÛ²k5>g©R§Ê´wd¢\ÎIB\á™\Æ\Øû\È©n\ÖL ,\0ÀP\Ç8÷þŸj\Ü:o@\Ù\0\ãu¬«™Ày \íÏ½SI“4VkŒ	`!NÓ‘Á©­cË•\Â‘‚;ŠÄ–\é\æ0Å°2‚O¡\ç\×\é\Å_\Ò^\â\Ñ<\Ðraþ\î;}?­d\âý£¶†õµ‡™©\0õü*\äVˆ\Ú;V`³„<Š’\å‚`¿1T;!]³.\æ³\ÊmUZFCŽ\Ü\×qa¨\ÛH\Í5¬±±;² Â½~Q\ÏNõ(7€3D*¸T¹·<\à[}©\Ù\Õ\Ùw p£¶zÎ©d\Ç,x¯M¸\Ó\à~öo¨þµŸ\'†m\\\Ó>‡#õ¡I_SÍ«—7¬,y\ëÛ¶\Ü\ï?•\Ø\\xf\æ,˜öÊ¿‘¢¶\\¯©\Êð•œ¥›+»{«Q=»Œö^1\ìGcL’W\nó\ÛF\ãNŸÍúý\å=\ë]¶—ª[\ê\Ã\äù$^Z2yýjš´\åz\Õ9\Æ^¦\ÔL\Ûy\ç5#G¸­ B#r5qYš˜·18:UXf\Ø[\'û¾µ¿<*ÉƒYsY\Û\Ôa‡Z°\ítJ·je‰<|­Q\ÜF³7;“n@ëœŽjœ\îŸQQþñS\0ð\0«\Ú\ìŠ?bò\î¶\ç(Oq\ëZ¶V¬“ù­\Äcù\Ö{¼Ñ¨  \è1W\"»•¤68\ÍC˜ý™\Ó\Ã*$@ò3\ÅEyvªœóØŠÈŽy|­¥¾l\çw¥9\Ì|·oZŽb\Õ;a!À\é\ëZ\Ç\å\'Njœ?/AW\Ñ\Æ9¤†Ä“\î\ç­¸\Û\Ç\åOÀ\ÇÖ«²l¯J¢M‘e`¹\0ŸZ*¤r~tS\àÙ©m\ç–\Þe–$S•a\ÔTDRt¯Ló\ÏFð\ï‰\á\Ô6Z\Ý2\Åw\Ðg\î\Éôô>\Õ\Ó|Àý\rxž\ï~•\Úxs\Æ?r\ËT“\Ú;†?£rÔ£mbtÓ«}$wwj´˜\ÍHd¤{Š…ƒž+˜\êEYvõª­&AWsÁª2Às\Å&Zfû´\år\Ý)žA\ÍM¸\'´¬1ñ±\éœ\Õ\ØA\ÛQ%¾Î¢­\Ç\ÆE\Éb\È<Õ¥l\nx\íÒ¤¦‘›\'Y\r?!…VÔªø Lpx¢œNEÿ\Ù'),(2,'BMC01','CMC01','DMC01',3,2,19,31,564.60,786.33,10.0000,2.0000,'2024-11-13 22:00:22','1 ANO',_binary 'ÿ\Øÿ\à\0JFIF\0\0`\0`\0\0ÿ\Û\0C\0		\n\r\Z\Z $.\' \",#(7),01444\'9=82<.342ÿ\Û\0C			\r\r2!!22222222222222222222222222222222222222222222222222ÿÀ\0\0 \0ˆ\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñð$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rðbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0È¢Š+\ã·<¢Š)l+¢Œf¨\ÍÀ\Í \ä\ÑÕ½©t)=\è\ÆNi3ƒ‚(\Îµ5±6b\çŠ:u\ïE*úX(¢ŠIØ… QE_R\ØQE\ÄQEAQD‘H(¢Ž\Õ*\â~BñH€¹1¯\Þ\íH0ùy5\Õøw@7n¤^õ•jÊœnÎšyTv¦xm®4¶–Uùñ\Ås—V²Z\Ì\É #Šö%#UT\\(\×?¯ø}/‰–5\Æk\Ì\Ã\ãùª5-V¾\ÔÕ7ûÆ–Ÿ42A;£Œ8¦W°µW<9ÁÁÙ…QNÄ…QA2º\n(¢™aŽqE/l\ÒœÔ¶&¬‘EÁ \äT…p\èh\ï\Í\rŒS[ž\Ðäº¸*«*•#Ý›Ñ£)\ÍX±\á\Í	§”K\"ü†½h­`Ú„*U\Õ`\Ò,²ø\nyŠ<{$7O«\åzq\\ø\\\\}M´=\è(a\ã\æz4ºÕ¼NP¸\ëW\í¦Ž\æ\Ê\ã¾z\ÝJûÙ­ji><»‚u˜\ì\Ï5\íW\ágOš+R?š\\¬ô¿ø}g‰žùºœW$M¦&^¥¡kVúµš…!˜ŽkÄ¾ùZhW\æ<ñ^:“£QÒªe‹\ÃFkž\'\r\ßw¥‘\Zµþõ\'NkÑ‹¹\â¸ò\î\ç(\ã­š]Iz…QLø¨\êh4tZ\Z¶¡}9âž1Þ—8æ´´m*MNoºp\rDæ¢¹™¥:.r²%\Ñ4i/¥\ÊvŠô»8­m–0 :\ÔZ}ŒVVÊŠ 69«1ò\Ûq^lD±y\"}>\n¨\Â\ìóŸˆ~)#X\Ç&\ë^O¸¾Y\Î\âNkÐ¼I\à\ë½WW{œ1Rx®z÷Â—6*K!\àzW\ë|?†…<y–¬ðñ•\\§¡€GJ\n\0œi\ÏÑ±\r\0=©2sÈ¯¨\å¦Õ™ÁvÎ—Ášüº^¢‘\È\çku¯v‚H\ï-SóóLn²/Ps^\ç\à\r[ûWF\Ú[-\Å~m\Æb‚U o-­\Ï\îÈ©\â?^x—ßŠ\ã™YN\Ç\àŠöb‰2\ìdW\â/²K%\ÄKòŽx¯‘À\ã9—$‡Á[ß‰É\Æh\íšO›î‘ŽiOMµ\ë-\Ï\r¦ž¡š(\è1E0ÒƒúPzU\Í6\ÂK\ë•E\\©\ëPä¢®Ê…7)YÒ´\Ù5Á@vƒ\Íz^—¦E§@¥n#š‡D\Ò#\Ò\í\È*2Õ¦O8\í_?Œ\ÆsË–;OƒÁ¨+\È\Ì\Ä\Õk\Ëøtôb\ïZ²:\×ñR\é\íl\íJ15®GC\Ûc¡\çV*|”›5.<]e\Û2µR÷^\Ò\ïQ\äó^7sq4\Ò\ïóOZ`ûZ¦ó#m=9¯\Úá…•8(£\ä\ÜÔ¤\Ù\î~\ÑõŽ\Ã0\\ñ^q{\á‰m¬fr¿2š§\á\ï\Ü\èlÅ¤fV3]¶‘­\ÛkR	°ú\Ô\Æi»\É\è&\Ó<¨“’¤r+\Ñ~^›yd·\'\ïš\Äñ†eš{T%<S¾\ÌS\ÄQBx9\äWx¡‰ÁIöF\Ø98UG¹\Z’H\Ö\á\Z\'Ÿ ý\á¦µøg3Œ®®”T\ãfp\Zÿ\0‡\Þ	žXW\äñ\\¸?9\Ïjöi¢Ž\â\Ý\âe°\Åy×ˆ4±%\ã^	\Í}¦¹e¹ó\Øü+æ‰€y9¢€x\Çz+\Ó<f±]†õ(l¤	 ‰®<\Ð8pã¨¨œ\ãcJs\ä\ÏfYXQ”\çp£®#Ãž! ˆ§nœ\×ndŒ:œƒ_1‹\ÃJ”Ï¬\Â\âUH¤À¯8ø¼	°µ>õ\èÝ«ø¦¶£¤®Á’‚½.\Z¨¡˜\ÂL1\êô\âjŒÝ¸õ«’Î‡OX\0ù…Z›ÉNXF<\àpk-£1¶­~ñó$ÏÙŽo‹q)ð]\Ík)ˆ\0Ô«\"­¦;\ÕC\íU8©\ÆÄ¦\ÏQð·ˆm5±]\à±\\d\Õ]7\Ã\Òi^7IQO•#d\Zó\Û)ä´¹Y\"\'p=«\Þ|#wm­ii3\à\Ïük\ås\Æ\èaf—Tz$§Q\\\èdûõSK’O4–\Å~&õ“>±h…^À®o\Äú­º#BpI«\Zæ´–P´j\Ãx¯:»º’öVw\'­zù~\ZW\ç‘\â\æ8¥nX‘ó±õ4PWº|ó\02´tv\Å\Ï\×aK¸¨\Æ9©\Æ+µð×ˆ<\Â\"¸\×\Û©#\ÂÀ\ÆqŠ\ç\ÄQXò³³\rˆt\ÏfR²\ë÷OJ¡­E\æh·X`§‡\á\ß	cH$nGZ\ë6¬\ÊGTa\ÍxtÔ°x….\Ç\ÑÓª«Ó±óV\Æ]J_;!ƒ\r:\é77µt4i,u§¸…½+›7\"[EN\ã­~\ç”\â\ã_\r	\'­™\Ä\Óq›D¶$¥•\Ï\0qU™~È½sH²2r¦­\ÛÂ«ºcÞ½M•\Îu®o‚\àGw¯Røam,P]Hù\Ø\Ç\å¯<’ÝµK\Ûhm\ÆA#8¯p\Ð4õÓ´x¢U\Ãmù«\à8\ÃR\äS\×\Ëh¾k³D|ÇŠ\Ê\Öux¬m\Ûk0\n—T\Ô\âÓ­\Ë\î±^g¨\ê\ß]<…Ž\Ö=+óœ\r\Íó\Èô1¸\ÅMr¡—\×\Òj´ŒÇ­W^ \àR“Ú½õ•‘ónnn\ìJ)q\Îhª3\n(¢‡ Ö¨=\è#4Q\Ð\ÒZd:)^\ÜîŒ\Õ\è>ñ\nIk7\ï×ž·{Ó \ígYTž9¬1uR6gf\é½OJñ>ƒ¯§²€…x¯\n\ÕôYôK‡‰\Ðõ\â½\Ã\Ã\Úüw1¨”‚ý0j}o\Â\Ö\Ú\ÃùÎ£&»2|\âYt¹j½Jµ‰JQ>w\Ø\å\åS[™\îœZ¢¶×²7\Ã\ë@\Ø\Ú*å—€\ì\í§YBŒƒšúš\ÜcA\Ói°\Ë\'\ÌcøÂ­h‚{µù\Ý\ÍvúŽ¥—ŽG··\éÖ¡¨\â¼\ÛY\Õ\ä\Ôn;Tñ_‰«<}ny|\'eZ±\ÃC—©§ª\Í{w(,|²x¬ð0)q… ûW\\`¢´<J\Õ\åvQE]\ÌQE†QE€Q\Ô\Z):\Z{qGN{Q÷º\Ñ\î(\'°¢÷X–\Ö\âKK…•X€§5\é\Zºš‚¨vÁ\æX\ìjÅ•\ì¶S+! \Íq\â°Ê¬|\ÏCŠ”$—C\ØO\'Ž•Zúõ,­K³a…e\Økñ\Íf°ÊŽk’ñ¸÷·#opq^=,\åR\Ïd{U±±;­Èµ\ímõ~V8ˆ\æh\'\ëAâ¾‚8\Â6G\ÎV¬\êJò\éK\Ðb”žôŸ\ÅZ°¢Š)H-`¢Š(QE(\ê(¢€AÚŒw¢Š€.ri½sKE\0´%†\îH#(¤\à\Ô uby4´RI&T¦\ÚÒŽ£š(¦C\Ô(¢Š\0(¢Šc\n(¢ÿ\Ù'),(3,'AAA','AAA','SSS',3,3,9,31,656.89,787.99,5.0000,1.0000,'2024-11-14 04:13:30','1 ANO',_binary 'ÿ\Øÿ\à\0JFIF\0\0`\0`\0\0ÿ\Û\0C\0		\n\r\Z\Z $.\' \",#(7),01444\'9=82<.342ÿ\Û\0C			\r\r2!!22222222222222222222222222222222222222222222222222ÿÀ\0\0 \0ˆ\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñð$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rðbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0÷ú(¢€\n(¢€\nJ^\ÔÀ\Ùi…¤£>ô‡9£ah;ž\Ôß›=€9!~¦«\\\êV6‹›‹¸cÿ\0y\ÅK’)+\ìZÈ£us\×>3\Ðm¸7\ë+v Xšž\ÇÄºn¡x¦\Øs“|¦¡×§‰\ì§k›Y¥s#¦U\Ã\ÜSó“Áü+H\ÉKT\Èw]÷¥¦\Ïz}PjQE\00HqN\ÏÖ¸oˆ\Þ/ŸÁš5¥\í´3\Í8ˆ\îÀÁ5\Ã[|KŸV\áµW·cü(»+*µ]8ó8³Z4eU\Ù\àdE\êÀ}MS¸\Öô\ËN\'¾‚3\î\Õ\ä†W¾I/f¸û\ÒñLð)ùbö¯¦u»(ž¥<žr\ÞG¤\\x\ëB„\í[–˜úD»«6ˆPcýM¹“\ÞOWv.V8…¢û¹À\íP\Ü\ïS=\äQlzV2\Íj½‘º\ÊiG\â‘\Ö\Üx\ïT‘\Â\ÃionOMòn5›?Š5»‰Z#ªFŒJAó®Z{½&3#\Þ_F\î\Ç9V\Æ>•FO\èsnY\ÞGUÛ“Ö£\Ú\â\ê;\Ææ‘£„§ñÆ«5Ô¡\'¿¼•\ÏPòñP:…“jZ‡\ï¸\ä\æ¹I¾!X\ÆO\Ù\ì·dõ+“Y—?õr-\áT^\Ç8«XLeMÁ\âðtö±\è{.™†\ß\Ý!\çS\Ñ\Ö\Û=\Ê\ß\Î+\É.<U­\ÜõŸo\ÐU.õšK©ï‡«ŽT\Û÷¤g<\ÕZÑ‰\îºÿ\0“*\Åg{)ôTl\Õ\ïøY\×úT\â\Ö\î\ÆIe\'j†L_<Ê’p\âV\Þ;–9©e\âÿ\0iª±Å¨\Èñ‰0zT0q¥ð¶yÕ±\×t}]¦x¦\Îò\Þx\Z\Ê\êNK\Ã\Z\ÝI£‘C#S\ÜW‡ü5ñKjis®\Ü\Ä\ÞØ¹,¸\ãø¾•\é^Ô ¹óÁ	o$›]m\Ù\ÆpG}k¸\âhê¨¤( “\Äþ;jvÏ§\éú<ry—\É7žñ)\ä W‹BùÀn¯q^û@Y,/\Ò\î¢b’KjÁˆ?\Ý<W—Å¨”\âx–Uõ^Qk+#H·\Ð\èlµK\ËFT\Ìq\Ó\'­Mq\ã\íW\Î[h‚+\ä.ò:g½d\Û\Ëoq´Áp7qøoþ½g]A,:˜’X™Wx9\Ç\Ï<-)üJ\æð\ÄUŠ²‘\é\á½WV·Gµñ`¾•¸xl¾ôGÑ‡z\Å\×ü?\â/\Û,úº[\ê\Zl¤#J¯Ê“\Øú\Z«ð\â\æ‰Ö³Hß»yŽ\ì\Åt¾5ñ6§\â\ê\ãSKt‰uM–)Ú‡?—Z¸Ñ„tI}\Ä:µ»là¦·\Ðu%{{‹»K¥-¼£xcõ\íYkl aŠƒ\èi¶\Ò\çF`\n†\æ¶{@vÁfòW9­D\ÞOvfˆWÐŸ÷G2Y\Îøò\í\ßò­t7»r±En¾¸£òDú†}“š9PÆ›uÿ\0-Qö\ß\ï±[§ú\Ë\ÌûF»ªO>\Ê/ùfòVzi\ÔGü²·ˆÀrj¯¦¢QH–K#È·ž_v8•[\Çùl\àGvŠ\Ík»\É\Æ7H°\Å3\ì\ÓHrî¿‰\Í \Ð\ÒMA Y\Ìp\èbu‰°Olw¨\ÓVŠ„¹Œ\Í\ç¦6Le ¦Þ•Ul\â\Æ$‘›\Û5?Ù’4V\0q‘Ú“hv\Ðú›ÁšÎµ\á-;Q¼fš<±=À=h¨¼óxI\Ïx©¢™“<ö‡ˆoBX$}Ex\Ç^1Ó¶+Û¿h€\ÃP\Ð\\~\îAúŠñBÁ\Ç\Î3\î(*;3\Ç\r\ê:Š·¡s\ívó“uùªÌ‡¯ò¦gƒ@¾Þˆ\âH#\Ù ;ƒ‚§Úª¼²JIf,I,w‚OZoµim—\Ë1þ@\Èc—a8\n\ÇÔŠ·\Ý\Ù\\)p=b”F±¶<½¬;\Z”nŸÂ¡\'\îcƒ\êÍšxA\Ë>?\Ý\çNiA b„…y	“\êM<6:AL¥ixfõ??\'¹ý*1SF’;\0‘»ú\í›Š\Ük™\ì(\Î=ª\å\Ý\ÚOn‘ \Æ0X\ãùS \Ñ\ïe\ÌhDhN&«^@Ö—2[;1œVw„¤]§ŸOø\éõ\Çúš(ðüˆšGýpþ¦Š\ÛmŽ}÷<¯ö‹\é\ZzyŸÒ¼@õ¯sý¢T‘¡7»\å^@\ã°w\È8 \á\Ì9õ¤4P0\Æ9­k7Ž;\ÒwLøVI«\Ù\çŸACWE\'fZºœI((2Q6\îõ¨Œ¬\ØbH\ÏTcŽ•=¥µ\Å\å\Â\Û\ÛFe•¹\n;{šI$µ*\í½Á%ö\à–\í´dÖ”:.«p…¡°œ®3¸®+gH\Òe\Ó\0k*+‰\ä²\ç”½\Î=jÕ¥­ôÿ\0l»º¹½\"	\ã[Y±¸–\ÆHô®:˜¤ö:\á„n:œ†=A^üõ\\u”u«z¼‰&µz\è\0S.8\é\Ç_Ö©ô5\×Mó¥&r\ÉrË•\îOQŸjßŸ\Ä…†;U#>G\ß8®<\Øõ§\ç#µœ\éÆ¦\ã„\å\rµ«\Ùd½bP¥v\'AT$‘\är\î\å\ÛÞ›Þš\çƒU(\è…)\Ê[ŸU|?ÿ\0‘Gÿ\0®\Ô\ÑG\Ãþ<¤{AýM¡ƒ<\Ïö‰\ì\ÚóÙ‡\é^z×½~\Ñ\0ÿ\0f\è¬;N\ßÊ¼\ÐR\Zh¤4PU€Õ¢yüUn•dÿ\0A@ia\áªkf\Ä\è­pðD\çlŽ¾•W8§ w\ÈUs\ë´d\â¦M5k–“M4Žú\ÃY‹N&r\Ú{\ÆÁ\\EÃ‘\Ó#\×5•õôzd\×\ZºK\Z,þp’c\Ë÷QW\ëX\Z\\º\ìv‘%œ\Í­Ô¥’\0\Ý\ß°õ«÷š$\ØIõ-L\Þ<²\í\Ö6\Ý\æ\å}‡­p{(E´z©9DÁiL²¼®6™±Sš,¥•X¨$/J\ë%\Ð,aX£¶³h‘\Â#Oq»žÿ\0-]\Ôõ(bðÞ¤-ž)68·tŽ0¯½hñ6j0W2ú«\ÕÉœH#8\ï\éOúU`ùÚŠzñž£ñô­ig\çQ¦Lp\rõ\Ô\ä–\è\äŒ\\ðy¦38«_l\Ó\àÿ\0{“?\Å;d~UR\æòK¹È±¡vŒRR¸Ú¶\ç\Õ\Þ\0ÿ\0‘Hÿ\0®\Ô\ÑG€?\äB\Ò?\ë‡õ4Vˆ\ç{žwûCÿ\0\ÈGoK£ü«À\r{\ç\íþg‡ô ?†\ëúWš\nBQEŠV3òý«õ« úQp\êuÖ¾ŽóF\Ò.¡’&™÷J\×`?<\0+kN[]Qž]@\Ãl÷Ò˜•v|¾X\à\à{žõ\Ä\\kW3?\Ë5°dDw>¦ª\Ý\ß]_\Ìg»¤”÷=‡¥rû\Ê\êOOø\'lq\ãªZf¡™m™¥\Ý_F¶¶òK4\Í\ÌH\'õ5OZ\×t›»\Ûy\ìm&i-ðJ\Ø@€p¡k—À\É\às\ïÒ”)c´\nµA\'©\ÄÉ­\r‹_Í°F[m}ÿ\0¹Lø\ÖO™&\æË³9bOSK\å0±\n	\èiÀ­¡\ÇDŒeRrÝ‚¶3€}85z+U1†lóØŒgñª\ãn1ú9\È\á¾f ö¥7a%anWÊ”®\nÀžjò*kùc’\í\ÞE<s“U\Ç\'ñªŠ\ÐLú\ß\áÿ\0üˆš7ýpþ¦ŠO\0‘ÿ\0.Ž\Ë2=\Í\ÌN\ã^}ªøze	™­¦ó$U\ë·«\çƒ\ÜATõö¦¥b\'Œ€pqŒü\ë\Ä|uð\Ý.\å{\Ý:5¶º\ê\È\É!÷ô4¢¥¹µ¸²¸{{¨š)á”\åQR(*ÁÀÛŽ\ë\ÍW\íSŸ\áÿ\0v€$XðU	_SÒždü\íƒ\è)\É(Øª1\î¨\Ç\ëH\ÆAó3\"/M¬rEMËµµ$Xc\r÷y\ä\Ò<\ÞXùB–\ÏMCº<r\ÎýñÚšÍ¸Œ\"¨\Çc\Í;0¸\ç‘\äû\ä}*>ø<Rf•7J\á\"\åsÀ3T‰¸g¶jX\åt\ÉQßŒ\Ö\î™\àjŒ<»3\ã˜\àWs£|\ZW*úüŽ{¤#ó¡Ù“s\É\Ôn\ÂõúrksHðŽ¿®J‰§i“¸sþ±\×j©¯ tO‡º”ƒKˆ°þ99jì­­<µ\Ú@\Æ\0h‘OÂºdúG†¬4ë’­4m}§ cEl¢\íŠ9”0\Åf_\é©:®kVŒŠx\ïŒ|mª\Äû\ã\Ú\à²(ù—ÿ\0­^­øzû@¸1\Ý!h¿‚u7\×Ò¾È¹³Žt!‡5\Æxƒ\Âp\ßC$oº0\åH\ë@\Ó>T=:ð{Š›?(ÿ\0v»Oü6¿\Ó\æi4\Ø\ÚXs\Ì_Äµ“m\à­z\å•~\Ç\å.0ZCŠL«˜¦Y07\Ê?º9¨—<œû\æ½MøYq7ü~^1\Ö.?Z\ìôŸ†:m±V˜ƒ&‹	³\Äml/\ïH¶’Ëž\áxü\ë£\Óþ\ë7¤y\Æ;d>Ÿ1¯|²ð”P¨\Z€;ŠÝ¶\ÐbŒP\ïLW<_IøMf^\è\Ép\Ã\ÔñùW i\n´±P-\í\"ˆ»]\ÔV \Æ\ÜU•„.8\é@\\Ã¶\Ñ08µ\"±DtUÍ£­ Dk¯jR\Ñ@Q@Q@E4\"E\ä=*Z(\çFŠf\É_¡ôª©\á\èTý\Ñ\í]\'”`zP\\:L)ƒ´~Uu-Q„UŠA@\r¨\íNÀ¥¢€\n(¢€\n(¢€\n(¢€\n(¢€?ÿ\Ù');
/*!40000 ALTER TABLE `DBProdutos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-14 16:54:30
