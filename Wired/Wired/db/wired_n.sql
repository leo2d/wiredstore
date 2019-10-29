-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 05, 2018 at 12:13 AM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wired_n`
--

-- --------------------------------------------------------

--
-- Table structure for table `promocodeviewmodel`
--

CREATE TABLE `promocodeviewmodel` (
  `Id` int(11) NOT NULL,
  `Coupon` varchar(75) NOT NULL,
  `Amount` int(11) NOT NULL,
  `DiscountPercent` int(11) NOT NULL,
  `UsedAmount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wired_admin`
--

CREATE TABLE `wired_admin` (
  `Id` int(11) NOT NULL,
  `Name` varchar(120) NOT NULL,
  `Email` char(100) NOT NULL,
  `Password` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_admin`
--

INSERT INTO `wired_admin` (`Id`, `Name`, `Email`, `Password`) VALUES
(1, 'Leon S. Kennedy', 'leon@rpd.com', NULL),
(4, 'Claire Redfield', 'claire@mail.com', NULL),
(5, 'Caroline Lacerdinha', 'caroline@wired.com', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `wired_cart`
--

CREATE TABLE `wired_cart` (
  `Id` int(11) NOT NULL,
  `CustomerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wired_cart_item`
--

CREATE TABLE `wired_cart_item` (
  `Id` int(11) NOT NULL,
  `Amount` int(11) NOT NULL,
  `GameID` int(11) NOT NULL,
  `CartID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wired_customer`
--

CREATE TABLE `wired_customer` (
  `Id` int(11) NOT NULL,
  `Name` varchar(120) NOT NULL,
  `Email` char(100) NOT NULL,
  `Password` char(255) NOT NULL,
  `Cpf` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_customer`
--

INSERT INTO `wired_customer` (`Id`, `Name`, `Email`, `Password`, `Cpf`) VALUES
(5, 'Jack Hannaford', 'jack@company.com', '40BD001563085FC35165329EA1FF5C5ECBDBBEEF', '6666666666'),
(6, 'Jubileu', 'jubileu@mail.com', '40BD001563085FC35165329EA1FF5C5ECBDBBEEF', '999999999'),
(7, 'James', 'mail@mail.com', '7110EDA4D09E062AA5E4A390B0A572AC0D2C0220', '99234234999'),
(9, 'Jill Valentine', 'jill@stars.com', '40BD001563085FC35165329EA1FF5C5ECBDBBEEF', '85231922048');

-- --------------------------------------------------------

--
-- Table structure for table `wired_game`
--

CREATE TABLE `wired_game` (
  `Id` int(11) NOT NULL,
  `Name` varchar(80) NOT NULL,
  `Producer` varchar(80) NOT NULL,
  `ReleaseYear` char(4) NOT NULL,
  `ShortDescription` varchar(255) DEFAULT NULL,
  `Description` longtext NOT NULL,
  `Price` double NOT NULL,
  `GenreId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_game`
--

INSERT INTO `wired_game` (`Id`, `Name`, `Producer`, `ReleaseYear`, `ShortDescription`, `Description`, `Price`, `GenreId`) VALUES
(1, 'Resident Evil 2', 'Capcom', '2019', NULL, 'dasdsdfvdsfsdfsadfsadfsdffasdfasdfasdf', 129.99, 6),
(2, 'CyberPunk 2077', 'CdProjekt Red', '2019', NULL, 'jgbydfsrewaqea', 124.99, 1),
(3, 'Devil May Cry 5', 'Capcom', '2019', 'Shabitasse aptent sapien pellentesque magna, quisque vulputate dui rhoncus arcu.', 'Lorem ipsum praesent elementum sem risus, etiam aenean orci massa turpis, lobortis facilisis class primis. phasellus maecenas egestas habitant dictum ut varius vitae convallis laoreet nibh, nullam aenean tempus himenaeos at placerat ultrices pulvinar vehicula, mi nunc neque sapien senectus sem ultrices egestas id. mauris rutrum sagittis arcu himenaeos sem purus, habitasse aptent sapien pellentesque magna, quisque vulputate dui rhoncus arcu. habitant erat condimentum pulvinar phasellus ac venenatis massa faucibus tincidunt, ullamcorper nulla nullam feugiat nulla accumsan malesuada semper nam malesuada, eleifend mattis senectus vulputate consequat non accumsan nostra. ipsum ultricies suscipit ac suscipit arcu tellus, consectetur pellentesque tellus nulla. ', 99.9, 2),
(4, 'Far Cry 5', 'Ubisoft', '2018', 'Donec tempus ante habitasse facilisis quisque imperdiet', '	Lorem ipsum urna nullam sapien nullam mollis, accumsan proin nec cras bibendum, sagittis convallis aenean tempor sociosqu. sodales pulvinar nullam iaculis tincidunt donec suspendisse leo lacus, fames non pellentesque dictumst non ante pulvinar class non, fermentum dictum orci tempor venenatis tempor conubia. sodales aenean sem ante morbi purus id himenaeos, rhoncus fermentum curabitur commodo leo eu, tellus nostra dolor ante curabitur suspendisse. tristique pharetra dictumst pretium malesuada commodo auctor augue hendrerit, lorem feugiat auctor tempor ut placerat dui. lectus turpis nulla elit odio donec per suscipit, molestie sodales aliquam vehicula mollis eu porttitor nulla, sollicitudin commodo aliquam purus quis mollis. ', 99.9, 4),
(5, 'Shadow of the Tomb Raider', 'Square Enix', '2018', 'habitasse aptent sapien pellentesque magna, quisque vulputate dui rhoncus arcu.', 'Lorem ipsum habitasse sapien quisque sagittis eu magna augue litora maecenas class, elit nibh proin donec scelerisque suscipit sagittis integer mollis in, torquent hendrerit blandit pretium ornare sapien cras blandit sociosqu proin. sit nibh nisl tristique eros elit, cursus massa rutrum lorem metus molestie, viverra inceptos tristique quisque. sodales ac aliquet ad enim conubia sem sed ligula per, ornare metus congue vulputate nibh luctus ullamcorper luctus eu curabitur, semper eget condimentum etiam erat eget sem varius. maecenas purus curabitur hendrerit amet odio rutrum risus volutpat lacinia proin, justo sem quis fermentum ipsum porttitor placerat dapibus. ', 129.9, 4),
(6, 'Fallout 76', 'Bathesda', '2018', 'Mais um fallout', 'Fallout 76 é um jogo multijogador online de RPG de ação, desenvolvido pela Bethesda Game Studios e publicado pela Bethesda Softworks para Microsoft Windows, PlayStation 4 e Xbox One. Funcionará como uma prequela para a história da série Fallout e deverá ser lançado em 14 de novembro de 2018', 60.4, 3),
(7, 'Final Fantasy X', 'Square Enix', '2001', 'Um dos melhores games já feito.', 'Ajude Tidus e Yuna nessa jornada', 49.9, 1),
(8, 'The Witcher 3 ', 'CdProjekt Red', '2015', 'Ut condimentum aliquam auctor dolor fringilla', '	Iaculis sed lectus arcu est aliquam taciti pulvinar, ultricies donec dapibus vulputate dictumst pellentesque sagittis porta, semper odio malesuada amet ante eget. arcu eget consectetur ante euismod facilisis donec eget, vulputate nam praesent potenti himenaeos vulputate rhoncus, est placerat fringilla diam platea senectus. molestie lobortis diam taciti rutrum platea potenti imperdiet himenaeos pulvinar, malesuada nulla nec eros volutpat enim placerat enim praesent iaculis, leo enim ultrices consequat urna mi ultricies curabitur. sapien lacus eleifend senectus quisque dapibus id justo arcu, cursus orci metus aenean facilisis velit rhoncus interdum maecenas, dapibus ultrices felis aliquet faucibus lacinia eu. ', 99.9, 1),
(9, 'Resident Evil 7', 'Capcom', '2017', 'Pulvinar turpis et felis class aliquet orci vivamus posuere', 'Ut condimentum aliquam auctor dolor fringilla, ligula pretium commodo vulputate magna, porta elementum maecenas est. vitae urna donec pharetra lacinia aliquam curae ad quisque, pharetra sapien vitae tempus quam leo feugiat arcu, sollicitudin pretium vel litora quisque laoreet ad. etiam bibendum phasellus scelerisque dui varius nibh mi aliquam cubilia, elementum sit mauris semper nisl elementum viverra mauris dictum, nisi mauris conubia vel vehicula maecenas neque vulputate. nisl est aliquet tortor aliquet velit condimentum vitae sollicitudin pretium turpis diam, mi curae tempus velit potenti feugiat primis arcu nec. ac curae egestas diam platea bibendum luctus aenean aliquet ultricies, sit orci vel vehicula sem tristique a eget risus gravida, felis elit nostra consequat dictumst orci erat taciti. ', 124.99, 6),
(10, 'Black Desert', 'Pearl Abyss', '2014', '	Augue sit quam rhoncus lorem ut, volutpat hendrerit nullam platea lacus,', 'blandit venenatis himenaeos dolor diam fames nibh tincidunt feugiat varius quisque vehicula lorem. urna morbi feugiat aenean mauris viverra massa dolor suscipit taciti, cursus aenean congue facilisis ultricies imperdiet vel congue enim, consequat nam sodales vitae himenaeos dictumst justo nisl. ', 45.5, 1),
(11, 'The Witcher', 'CdProjekt Red', '2007', 'Imperdiet ut elit amet erat felis non litora odio adipiscing ', ' senectus vestibulum venenatis class, viverra feugiat bibendum mollis. ipsum sem convallis habitasse enim potenti sed pulvinar libero proin nisl pellentesque, sit elit pulvinar mi cras nisi fringilla inceptos accumsan etiam, faucibus donec diam feugiat eleifend aliquam nullam felis consequat bibendum. lorem dictum molestie odio vehicula aenean nibh convallis pharetra, libero ante nullam elit donec blandit euismod ut turpis, aptent imperdiet neque pharetra sodales nunc molestie. ', 19.9, 1),
(12, 'Tom Clancy\'s Ghost Recon Wildlands', 'Ubisoft', '2017', 'usce dictumst laoreet mattis urna dui est ad ut, urna praesent aliquet', 'Aliquam rhoncus duis odio at consectetur massa vitae sollicitudin aliquam, in ullamcorper conubia ultricies primis litora augue. sodales quam nec bibendum consequat leo gravida felis quam, accumsan viverra sociosqu eget hac himenaeos in, tempus at aliquam feugiat lobortis vitae dolor. fusce dictumst laoreet mattis urna dui est ad ut, urna praesent aliquet vestibulum integer convallis in tristique', 129.9, 13),
(13, 'Gwent: The Witcher Card Game', 'CdProjekt Red', '2018', 'adipiscing nunc est vitae risus taciti nisi curae, quisque donec laoreet tellus nulla odio metus taciti lacus. ', 'adipiscing maecenas lectus egestas posuere enim. lectus pretium ut massa sodales risus morbi enim arcu sociosqu velit, dapibus senectus vitae sodales varius nulla tincidunt ut. habitant neque justo hac porta erat lacus vivamus viverra venenatis semper, et quisque adipiscing nunc est vitae risus taciti nisi curae, quisque donec laoreet tellus nulla odio metus taciti lacus. ', 0, 13),
(14, 'Playerunknown\'s Battlegrounds', 'PUBG Corporation', '2017', 'id dui facilisis semper, etiam facilisis mattis tristique', 'id dui facilisis semper, etiam facilisis mattis tristique non dictumst litora. iaculis malesuada ipsum netus porttitor erat ante, eros pulvinar sollicitudin maecenas nec malesuada nam, vel eros risus lectus etiam. velit torquent conubia suscipit fringilla primis tortor aliquet, praesent platea litora ante iaculis pellentesque, adipiscing maecenas lectus egestas posuere enim. lectus pretium ut massa sodales risus morbi enim arcu sociosqu velit, dapibus senectus vitae sodales varius nulla tincidunt ut. habitant neque justo hac porta erat lacus vivamus viverra venenatis semper, et quisque adipiscing nunc est vit', 60.4, 13);

-- --------------------------------------------------------

--
-- Table structure for table `wired_genre_game`
--

CREATE TABLE `wired_genre_game` (
  `Id` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_genre_game`
--

INSERT INTO `wired_genre_game` (`Id`, `Name`) VALUES
(1, 'RPG'),
(2, 'Ação'),
(3, 'FPS'),
(4, 'Aventura'),
(5, 'Esportes'),
(6, 'Survival Horror'),
(13, 'Outros');

-- --------------------------------------------------------

--
-- Table structure for table `wired_images_game`
--

CREATE TABLE `wired_images_game` (
  `Id` int(11) NOT NULL,
  `ImagePath` varchar(255) NOT NULL,
  `GameId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_images_game`
--

INSERT INTO `wired_images_game` (`Id`, `ImagePath`, `GameId`) VALUES
(1, 're2.jpg', 1),
(2, 'Cyberpunk2077.jpg', 2),
(4, 'farcry_8529f0.jpg', 4),
(5, 'Shadow-of-the-Tomb-Raider_4bd0be.jpg', 5),
(6, 'Shadow-of-the-Tomb-Raider-jungle_742eed.jpg', 5),
(8, 'final_fantasy_x_2a9037.jpg', 7),
(9, 'fallout76_e4c9a3.jpg', 6),
(10, 'Fallout76_logo_57107a.jpg', 6),
(11, 'Devil-May-Cry_dfb1cb.jpg', 3),
(12, 'DMC5_138c4a.jpg', 3),
(13, 'fallout-76-power_25a362.jpg', 6),
(14, 'the-witcher-3-wild-hunt-13_bef93f.jpg', 8),
(15, 'tw3_1eb717.jpg', 8),
(16, 're7_ffe2f0.jpg', 9),
(17, 'resident-evil-7_feac19.jpg', 9),
(18, 'black-desert-online_77eeb4.jpg', 10),
(19, 'Cosplay-de-uma-Bruxa-Black-Desert-Online-Witch-Topo_617d89.jpg', 10),
(20, 'tw_364405.jpg', 11),
(21, 'ghostrecon_9cf8d5.jpg', 12),
(22, 'gwent_capa_147faf.jpg', 13),
(25, 'pubg_64d137.jpg', 14);

-- --------------------------------------------------------

--
-- Table structure for table `wired_keys_game`
--

CREATE TABLE `wired_keys_game` (
  `Id` int(11) NOT NULL,
  `IsUsed` tinyint(1) NOT NULL,
  `Key` varchar(255) NOT NULL,
  `GameId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wired_promo_code`
--

CREATE TABLE `wired_promo_code` (
  `Id` int(11) NOT NULL,
  `Coupon` varchar(80) NOT NULL,
  `Amount` int(11) NOT NULL DEFAULT '1',
  `UsedAmount` int(11) NOT NULL,
  `DiscountPercent` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wired_promo_code`
--

INSERT INTO `wired_promo_code` (`Id`, `Coupon`, `Amount`, `UsedAmount`, `DiscountPercent`) VALUES
(1, 'marquinhos10', 20, 0, 10);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20181020132537_initialA', '2.1.4-rtm-31024'),
('20181020132906_cartConfigA', '2.1.4-rtm-31024'),
('20181020150425_PromoCodeConfig', '2.1.4-rtm-31024'),
('20181020151257_PromoCodeConfigUP', '2.1.4-rtm-31024'),
('20181020155226_cartConfigUp', '2.1.4-rtm-31024'),
('20181104191112_checkout_sale', '2.1.4-rtm-31024');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `promocodeviewmodel`
--
ALTER TABLE `promocodeviewmodel`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `wired_admin`
--
ALTER TABLE `wired_admin`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `wired_cart`
--
ALTER TABLE `wired_cart`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_wired_cart_CustomerId` (`CustomerId`);

--
-- Indexes for table `wired_cart_item`
--
ALTER TABLE `wired_cart_item`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_wired_cart_item_GameID` (`GameID`),
  ADD KEY `IX_wired_cart_item_CartID` (`CartID`);

--
-- Indexes for table `wired_customer`
--
ALTER TABLE `wired_customer`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `wired_game`
--
ALTER TABLE `wired_game`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_wired_game_GenreId` (`GenreId`);

--
-- Indexes for table `wired_genre_game`
--
ALTER TABLE `wired_genre_game`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `wired_images_game`
--
ALTER TABLE `wired_images_game`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_wired_images_game_GameId` (`GameId`);

--
-- Indexes for table `wired_keys_game`
--
ALTER TABLE `wired_keys_game`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_wired_keys_game_GameId` (`GameId`);

--
-- Indexes for table `wired_promo_code`
--
ALTER TABLE `wired_promo_code`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `promocodeviewmodel`
--
ALTER TABLE `promocodeviewmodel`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wired_admin`
--
ALTER TABLE `wired_admin`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `wired_cart`
--
ALTER TABLE `wired_cart`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wired_cart_item`
--
ALTER TABLE `wired_cart_item`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wired_customer`
--
ALTER TABLE `wired_customer`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `wired_game`
--
ALTER TABLE `wired_game`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `wired_genre_game`
--
ALTER TABLE `wired_genre_game`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `wired_images_game`
--
ALTER TABLE `wired_images_game`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `wired_keys_game`
--
ALTER TABLE `wired_keys_game`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wired_promo_code`
--
ALTER TABLE `wired_promo_code`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `wired_cart`
--
ALTER TABLE `wired_cart`
  ADD CONSTRAINT `FK_wired_cart_wired_customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `wired_customer` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `wired_cart_item`
--
ALTER TABLE `wired_cart_item`
  ADD CONSTRAINT `FK_wired_cart_item_wired_cart_CartID` FOREIGN KEY (`CartID`) REFERENCES `wired_cart` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_wired_cart_item_wired_game_GameID` FOREIGN KEY (`GameID`) REFERENCES `wired_game` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `wired_game`
--
ALTER TABLE `wired_game`
  ADD CONSTRAINT `FK_wired_game_wired_genre_game_GenreId` FOREIGN KEY (`GenreId`) REFERENCES `wired_genre_game` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `wired_images_game`
--
ALTER TABLE `wired_images_game`
  ADD CONSTRAINT `FK_wired_images_game_wired_game_GameId` FOREIGN KEY (`GameId`) REFERENCES `wired_game` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `wired_keys_game`
--
ALTER TABLE `wired_keys_game`
  ADD CONSTRAINT `FK_wired_keys_game_wired_game_GameId` FOREIGN KEY (`GameId`) REFERENCES `wired_game` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
