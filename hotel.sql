-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 02, 2023 at 11:14 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotel`
--

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `Booking Id` int(100) NOT NULL,
  `Guest Id` varchar(100) NOT NULL,
  `Room Id` varchar(100) NOT NULL,
  `Booking Date` date NOT NULL,
  `Status` varchar(100) NOT NULL,
  `Chack In` date NOT NULL,
  `Chack Out` date NOT NULL,
  `Days range` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `booking`
--

INSERT INTO `booking` (`Booking Id`, `Guest Id`, `Room Id`, `Booking Date`, `Status`, `Chack In`, `Chack Out`, `Days range`) VALUES
(1, '5', '4', '2021-11-01', 'free', '2022-08-01', '2022-09-01', '6'),
(2, '6', '3', '2021-11-01', 'free', '2022-08-02', '2022-09-12', '7'),
(3, '3', '', '2023-01-16', 'free', '2023-01-09', '2023-01-15', '32'),
(4, '6', '9', '2023-01-10', 'free', '2023-01-03', '2023-01-11', '76'),
(5, '5', '345', '2023-01-02', 'free', '2023-02-09', '2023-01-07', '23'),
(6, '34', '45', '2023-01-10', 'free', '2023-01-03', '2023-01-11', '12'),
(7, '23', '34', '2023-01-03', 'free', '2023-01-17', '2023-01-03', '23'),
(8, '1', '2', '2023-01-10', 'free', '2023-01-11', '2023-01-11', '45'),
(9, '12', '13', '2023-01-11', 'free', '2023-01-27', '2023-01-27', '14'),
(10, '34', '87', '2023-05-31', 'free', '2022-12-29', '2023-05-26', '56');

-- --------------------------------------------------------

--
-- Table structure for table `guest`
--

CREATE TABLE `guest` (
  `Guest Id` int(50) NOT NULL,
  `First Name` varchar(100) NOT NULL,
  `Middle Name` varchar(100) NOT NULL,
  `Last Name` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `City` varchar(100) NOT NULL,
  `Country` varchar(100) NOT NULL,
  `Room No` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `Maritid Status` varchar(100) NOT NULL,
  `Passport No` varchar(100) NOT NULL,
  `Booking id` varchar(100) NOT NULL,
  `Notes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `guest`
--

INSERT INTO `guest` (`Guest Id`, `First Name`, `Middle Name`, `Last Name`, `Title`, `Email`, `phone`, `Address`, `City`, `Country`, `Room No`, `Gender`, `Maritid Status`, `Passport No`, `Booking id`, `Notes`) VALUES
(9, 'rebin', 'majed', 'saleh', 'kjhkhj', 'rebinmajed@gmail.com', '878789798798', 'iraq', 'erbil', 'uyyuiuyu', 'uiyiuyiu', 'Fmale', 'No marrid', '8', '99898', 'kjhjh'),
(10, 'fsfs', 'ffsdfd', 'fdsfs', 'fsdf', 'fsfsdfdfsf@gmail.com', '234342', 'ffdsfds', 'fdsfsfdfsdf', 'sdfdsf', '34', 'male', 'marrid', 'dsf', '234234', 'dfdfs'),
(11, 'Mohammad', 'Nazem', 'Sahed', 'shdfjsdfhjks', 'm@gmail.com', '74657456', 'erbil', 'Erbil', 'newroz', '5', 'male', 'No marrid', '87', '68', 'fhufhgu'),
(12, 'R', 'M', 'S', 'jdhf', 'R@gmail.com', '865847545', 'Erbil', 'erbil', 'n', '798', 'male', 'marrid', '87878', '5', 'jhgjh'),
(13, 'M', 'N', 'S', 'ftyfty', 'M@yahoo.com', '07504309856', 'erbil', 'erbil', 'iraq', '6', 'male', 'No marrid', '543444', '65', 'hjgjgjhgkjh'),
(14, 'R', 'M', 'S', 'yuyuy', 'R@gmail.com', '46328746487', 'fdjhf', 'dhjs', 'fhsdjf', '4345', 'male', 'No marrid', '4783', '8978', 'rtuertyu'),
(15, 'R', 'M', 'S', 'jdhf', 'R@gmail.com', '865847545', 'Erbil', 'erbil', 'n', '798', 'male', 'marrid', '87878', '5', 'jhgjh'),
(16, 'R', 'M', 'S', 'jdhf', 'R@gmail.com', '865847545', 'Erbil', 'erbil', 'n', '798', 'male', 'marrid', '87878', '5', 'jhgjh'),
(17, 'R', 'M', 'S', 'jdhf', 'R@gmail.com', '865847545', 'Erbil', 'erbil', 'n', '798', 'male', 'marrid', '87878', '5', 'jhgjh'),
(18, 'R', 'M', 'S', 'jdhf', 'R@gmail.com', '865847545', 'Erbil', 'erbil', 'n', '798', 'male', 'marrid', '87878', '5', 'jhgjh');

-- --------------------------------------------------------

--
-- Table structure for table `gym`
--

CREATE TABLE `gym` (
  `GuestId` int(100) NOT NULL,
  `RoomId` varchar(100) NOT NULL,
  `ReservationId` varchar(100) NOT NULL,
  `Hours` varchar(100) NOT NULL,
  `Date` date NOT NULL,
  `Payment` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `gym`
--

INSERT INTO `gym` (`GuestId`, `RoomId`, `ReservationId`, `Hours`, `Date`, `Payment`) VALUES
(1, '2', '4', '5', '2023-04-11', '3');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `paymentId` int(100) NOT NULL,
  `GuestId` varchar(100) NOT NULL,
  `RoomId` varchar(100) NOT NULL,
  `PaymentDate` date NOT NULL,
  `Pricepernight` varchar(100) NOT NULL,
  `Priceperiod` varchar(100) NOT NULL,
  `BookingId` varchar(100) NOT NULL,
  `Totalamount` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `payment`
--

INSERT INTO `payment` (`paymentId`, `GuestId`, `RoomId`, `PaymentDate`, `Pricepernight`, `Priceperiod`, `BookingId`, `Totalamount`) VALUES
(57, '1', '2', '2023-01-01', '123', '1234', '123', '123'),
(58, '123', '1234', '2023-01-18', '78', '89', '678', '567'),
(59, '87', '87', '2023-01-12', '789', '76', '34', '23'),
(60, '34', '45', '2023-01-18', '12345', '244', '342', '535'),
(61, '242', '234', '2023-01-03', '2423', '234', '234', '34'),
(62, '234', '234', '2023-01-11', '2432', '234', '234', '4324'),
(63, '234', '4', '2023-01-02', '234', '324', '34', '234'),
(66, '4353', '34534', '2023-01-10', '345', '453', '345', '345'),
(69, '34', '45', '2023-01-18', '12345', '244', '342', '535'),
(72, '87', '87', '2023-01-12', '789', '76', '34', '23'),
(73, '34', '45', '2023-01-18', '12345', '244', '342', '535'),
(75, '87', '87', '2023-01-12', '789', '76', '34', '23');

-- --------------------------------------------------------

--
-- Table structure for table `pool`
--

CREATE TABLE `pool` (
  `GuestId` int(100) NOT NULL,
  `RoomId` varchar(100) NOT NULL,
  `ReservationId` varchar(100) NOT NULL,
  `Hours` varchar(100) NOT NULL,
  `Date` date NOT NULL,
  `Payment` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pool`
--

INSERT INTO `pool` (`GuestId`, `RoomId`, `ReservationId`, `Hours`, `Date`, `Payment`) VALUES
(1, '2', '3', '5', '2023-04-18', '200'),
(2, '7', '6', '6', '2023-04-03', '90');

-- --------------------------------------------------------

--
-- Table structure for table `reception`
--

CREATE TABLE `reception` (
  `id` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant`
--

CREATE TABLE `restaurant` (
  `GuestId` int(100) NOT NULL,
  `RoomId` varchar(100) NOT NULL,
  `OrderId` varchar(100) NOT NULL,
  `FoodItems` varchar(100) NOT NULL,
  `Quantitay` varchar(100) NOT NULL,
  `Date` date NOT NULL,
  `Price` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `restaurant`
--

INSERT INTO `restaurant` (`GuestId`, `RoomId`, `OrderId`, `FoodItems`, `Quantitay`, `Date`, `Price`) VALUES
(6, '5', '8', 'pizza', '6', '2023-04-19', '100$'),
(7, '4', '3', 'burgger', '2', '2023-04-03', '20');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `id` int(100) NOT NULL,
  `room_type` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `tprice` varchar(100) NOT NULL,
  `location` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`id`, `room_type`, `description`, `tprice`, `location`) VALUES
(5, 'Double', 'asdsd', '222222', 'sdssds'),
(6, 'Single', 'adsd', 'sdasd', 'dasd'),
(7, 'Single', 'sdff', 'fsd', 'fs'),
(8, 'Single', 'hjkdsf', '646757', 'gjfsgfhjdsf'),
(9, 'Double', 'hfjksfr', '900$', 'dfhdjfhd'),
(10, 'Single', 'xcxc', '123', 'sadsad'),
(11, 'Double', 'adasd', '12345', 'erbil'),
(12, 'Single', 'fhsdjf', '6454', 'dhjgfh'),
(13, 'Double', 'ddsfdsffs', '123312', 'erbil'),
(15, 'Double', 'jjuyui', '8798', 'erbil');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(100) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `Username`, `Password`) VALUES
(1, 'admin', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`Booking Id`);

--
-- Indexes for table `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`Guest Id`);

--
-- Indexes for table `gym`
--
ALTER TABLE `gym`
  ADD PRIMARY KEY (`GuestId`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`paymentId`);

--
-- Indexes for table `pool`
--
ALTER TABLE `pool`
  ADD PRIMARY KEY (`GuestId`);

--
-- Indexes for table `reception`
--
ALTER TABLE `reception`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `restaurant`
--
ALTER TABLE `restaurant`
  ADD PRIMARY KEY (`GuestId`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `booking`
--
ALTER TABLE `booking`
  MODIFY `Booking Id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `guest`
--
ALTER TABLE `guest`
  MODIFY `Guest Id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `gym`
--
ALTER TABLE `gym`
  MODIFY `GuestId` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `paymentId` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=76;

--
-- AUTO_INCREMENT for table `pool`
--
ALTER TABLE `pool`
  MODIFY `GuestId` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `reception`
--
ALTER TABLE `reception`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant`
--
ALTER TABLE `restaurant`
  MODIFY `GuestId` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
