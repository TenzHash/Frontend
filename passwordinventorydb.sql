-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 21, 2025 at 05:44 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `passwordinventorydb`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `add_log_entry` (IN `p_user_id` INT, IN `p_action` VARCHAR(255))   BEGIN
    INSERT INTO activitylogs (user_id, action) VALUES (p_user_id, p_action);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `clear_logs` ()   BEGIN
    DELETE FROM activitylogs;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_old_logs` (IN `cutoff_date` DATE)   BEGIN
    DELETE FROM activitylogs WHERE timestamp < cutoff_date;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_masked_passwords` ()   BEGIN
    SELECT 
        user_id, 
        CONCAT(LEFT(password_encrypted, 3), '*****') AS masked_password, 
        updated_at
    FROM passwords;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_user_logs` (IN `p_user_id` INT)   BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE log_action VARCHAR(255);
    DECLARE log_cursor CURSOR FOR SELECT action FROM activitylogs WHERE user_id = p_user_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    OPEN log_cursor;
    read_loop: LOOP
        FETCH log_cursor INTO log_action;
        IF done THEN
            LEAVE read_loop;
        END IF;
        SELECT log_action;
    END LOOP;
    CLOSE log_cursor;
END$$

--
-- Functions
--
CREATE DEFINER=`root`@`localhost` FUNCTION `check_password_strength` (`password` VARCHAR(255)) RETURNS CHAR(1) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    RETURN CASE WHEN LENGTH(password) >= 12 THEN 'Y' ELSE 'N' END;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `count_user_passwords` (`user_id` INT) RETURNS INT(11) DETERMINISTIC BEGIN
    DECLARE password_count INT;
    SELECT COUNT(*) INTO password_count FROM passwords WHERE user_id = user_id;
    RETURN password_count;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `first_password_update` (`user_id_param` INT) RETURNS DATETIME DETERMINISTIC BEGIN
    DECLARE first_update DATETIME;
    SELECT MIN(updated_at) INTO first_update FROM passwords WHERE passwords.user_id = user_id_param;
    RETURN first_update;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `format_date` (`dt` DATETIME) RETURNS VARCHAR(20) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    RETURN DATE_FORMAT(dt, '%Y-%m-%d %H:%i:%s');
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `latest_password_update` (`user_id` INT) RETURNS DATETIME DETERMINISTIC BEGIN
    DECLARE last_update DATETIME;
    SELECT MAX(updated_at) INTO last_update FROM passwords WHERE user_id = user_id;
    RETURN last_update;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `mask_password` (`password` VARCHAR(255)) RETURNS VARCHAR(255) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    RETURN CONCAT(LEFT(password, 3), '*****', RIGHT(password, 2));
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `actions_per_user`
-- (See below for the actual view)
--
CREATE TABLE `actions_per_user` (
`user_id` int(11)
,`action_count` bigint(21)
);

-- --------------------------------------------------------

--
-- Table structure for table `activitylogs`
--

CREATE TABLE `activitylogs` (
  `log_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `action` varchar(255) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `activitylogs`
--

INSERT INTO `activitylogs` (`log_id`, `user_id`, `action`, `timestamp`) VALUES
(16, 2, 'User logged in', '2025-02-21 06:52:16'),
(17, 2, 'User logged out', '2025-02-21 06:52:23'),
(26, 1, 'Delete password entry for Figma.com', '2025-03-15 08:54:00'),
(63, 1, 'Added new password entry for example.com', '2025-03-23 10:20:11'),
(64, 1, 'Updated password entry for example.com', '2025-03-23 10:20:56'),
(65, 1, 'Preparing to delete password entry for example.com', '2025-03-23 10:22:06'),
(66, 1, 'Deleted password entry for example.com', '2025-03-23 10:22:06'),
(67, 1, 'Added new password entry for asd', '2025-05-11 02:48:08'),
(68, 1, 'Added new password entry for asd', '2025-05-11 02:48:34'),
(69, 1, 'Added new password entry for facebook', '2025-05-11 04:00:18'),
(70, 1, 'Preparing to delete password entry for facebook', '2025-05-11 04:20:09'),
(71, 1, 'Deleted password entry for facebook', '2025-05-11 04:20:09'),
(72, 1, 'Preparing to delete password entry for asd', '2025-05-11 04:20:16'),
(73, 1, 'Deleted password entry for asd', '2025-05-11 04:20:16'),
(74, 1, 'Preparing to delete password entry for asd', '2025-05-11 04:20:21'),
(75, 1, 'Deleted password entry for asd', '2025-05-11 04:20:21'),
(76, 1, 'Added new password entry for ter', '2025-05-11 04:21:27'),
(77, 1, 'Preparing to delete password entry for ter', '2025-05-11 04:21:39'),
(78, 1, 'Deleted password entry for ter', '2025-05-11 04:21:39'),
(79, 1, 'Deleted password with ID: 42', '2025-05-11 04:21:40'),
(80, 1, 'Added new password entry for facebook', '2025-05-11 04:35:56'),
(81, 1, 'Added new password entry for asdas', '2025-05-21 14:30:51'),
(82, 1, 'Preparing to delete password entry for asdas', '2025-05-21 14:40:19'),
(83, 1, 'Deleted password entry for asdas', '2025-05-21 14:40:19'),
(84, 1, 'Deleted password with ID: 50', '2025-05-21 14:40:20'),
(85, 1, 'Added new password entry for asd', '2025-05-21 14:40:29'),
(86, 1, 'Preparing to delete password entry for asd', '2025-05-21 14:40:34'),
(87, 1, 'Deleted password entry for asd', '2025-05-21 14:40:34'),
(88, 1, 'Deleted password with ID: 51', '2025-05-21 14:40:36'),
(89, 1, 'Updated password entry for Facebook', '2025-05-21 14:50:27');

-- --------------------------------------------------------

--
-- Stand-in structure for view `all_activity_logs`
-- (See below for the actual view)
--
CREATE TABLE `all_activity_logs` (
`log_id` int(11)
,`user_id` int(11)
,`action` varchar(255)
,`timestamp` timestamp
);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(2, 'Banking'),
(9, 'Education'),
(8, 'Email'),
(5, 'Gaming'),
(7, 'Government'),
(4, 'Shopping'),
(1, 'Social Media'),
(6, 'Streaming'),
(10, 'Travel'),
(3, 'Work');

-- --------------------------------------------------------

--
-- Table structure for table `encryptionmethods`
--

CREATE TABLE `encryptionmethods` (
  `encryption_id` int(11) NOT NULL,
  `encryption_type` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `encryptionmethods`
--

INSERT INTO `encryptionmethods` (`encryption_id`, `encryption_type`) VALUES
(1, 'AES-256'),
(6, 'Argon2'),
(8, 'BCrypt'),
(4, 'Blowfish'),
(9, 'MD5'),
(7, 'PBKDF2'),
(3, 'RSA-2048'),
(10, 'SHA-256'),
(2, 'SHA-512'),
(5, 'Twofish');

-- --------------------------------------------------------

--
-- Stand-in structure for view `latest_user_actions`
-- (See below for the actual view)
--
CREATE TABLE `latest_user_actions` (
`log_id` int(11)
,`user_id` int(11)
,`action` varchar(255)
,`timestamp` timestamp
);

-- --------------------------------------------------------

--
-- Table structure for table `passwordentries`
--

CREATE TABLE `passwordentries` (
  `entry_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `site_name` varchar(100) NOT NULL,
  `site_url` varchar(255) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password_encrypted` varchar(255) NOT NULL,
  `encryption_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `passwordentries`
--

INSERT INTO `passwordentries` (`entry_id`, `user_id`, `category_id`, `site_name`, `site_url`, `username`, `password_encrypted`, `encryption_id`, `created_at`) VALUES
(1, 1, 1, 'Facebook', 'https://facebook.com', 'admin_fb', 'encryptedpassword1', 1, '2025-02-02 07:24:35'),
(2, 2, 2, 'Bank Account', 'https://mybank.com', 'user_bank', 'encryptedpassword2', 2, '2025-02-02 07:24:35'),
(3, 3, 3, 'Work Email', 'https://workmail.com', 'user_work', 'encryptedpassword3', 3, '2025-02-02 07:24:35'),
(4, 4, 4, 'Amazon', 'https://amazon.com', 'shopper4', 'encryptedpassword4', 4, '2025-02-02 07:24:35'),
(5, 5, 5, 'Steam', 'https://steam.com', 'gamer5', 'encryptedpassword5', 5, '2025-02-02 07:24:35'),
(6, 6, 6, 'Netflix', 'https://netflix.com', 'streamer6', 'encryptedpassword6', 6, '2025-02-02 07:24:35'),
(7, 7, 7, 'Government Portal', 'https://gov.com', 'govuser7', 'encryptedpassword7', 7, '2025-02-02 07:24:35'),
(8, 8, 8, 'Gmail', 'https://gmail.com', 'emailuser8', 'encryptedpassword8', 8, '2025-02-02 07:24:35'),
(9, 9, 9, 'University', 'https://university.com', 'student9', 'encryptedpassword9', 9, '2025-02-02 07:24:35'),
(10, 10, 10, 'Airline', 'https://airline.com', 'traveler10', 'encryptedpassword10', 10, '2025-02-02 07:24:35');

-- --------------------------------------------------------

--
-- Table structure for table `passwords`
--

CREATE TABLE `passwords` (
  `entry_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `site_name` varchar(100) NOT NULL,
  `site_url` varchar(255) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password_encrypted` varchar(255) NOT NULL,
  `encryption_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `passwords`
--

INSERT INTO `passwords` (`entry_id`, `user_id`, `category_id`, `site_name`, `site_url`, `username`, `password_encrypted`, `encryption_id`, `created_at`, `updated_at`) VALUES
(1, 1, 8, 'Facebook', 'https://facebook.com', 'admin_fb', 'encryptedpassword1', 1, '2025-02-02 07:24:35', '2025-05-21 22:50:27'),
(2, 2, 2, 'Bank Account', 'https://mybank.com', 'user_bank', 'encryptedpassword2', 2, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(3, 3, 3, 'Work Email', 'https://workmail.com', 'user_work', 'encryptedpassword3', 3, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(4, 4, 4, 'Amazon', 'https://amazon.com', 'shopper4', 'encryptedpassword4', 4, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(5, 5, 5, 'Steam', 'https://steam.com', 'gamer5', 'encryptedpassword5', 5, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(6, 6, 6, 'Netflix', 'https://netflix.com', 'streamer6', 'encryptedpassword6', 6, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(7, 7, 7, 'Government Portal', 'https://gov.com', 'govuser7', 'encryptedpassword7', 7, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(8, 8, 8, 'Gmail', 'https://gmail.com', 'emailuser8', 'encryptedpassword8', 8, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(9, 9, 9, 'University', 'https://university.com', 'student9', 'encryptedpassword9', 9, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(10, 10, 10, 'Airline', 'https://airline.com', 'traveler10', 'encryptedpassword10', 10, '2025-02-02 07:24:35', '2025-03-04 00:41:06'),
(43, 1, 8, 'facebook', '', 'Terrenze', '123', 1, '2025-05-11 04:35:56', '2025-05-11 12:35:56');

--
-- Triggers `passwords`
--
DELIMITER $$
CREATE TRIGGER `after_delete_password` AFTER DELETE ON `passwords` FOR EACH ROW INSERT INTO activitylogs (user_id, action, timestamp)
VALUES (OLD.user_id, CONCAT('Deleted password entry for ', OLD.site_name), NOW())
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `after_insert_password` AFTER INSERT ON `passwords` FOR EACH ROW INSERT INTO activitylogs (user_id, action, timestamp)
VALUES (NEW.user_id, CONCAT('Added new password entry for ', NEW.site_name), NOW())
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `after_update_password` AFTER UPDATE ON `passwords` FOR EACH ROW INSERT INTO activitylogs (user_id, action, timestamp)
VALUES (NEW.user_id, CONCAT('Updated password entry for ', NEW.site_name), NOW())
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_delete_password` BEFORE DELETE ON `passwords` FOR EACH ROW INSERT INTO activitylogs (user_id, action, timestamp)
VALUES (OLD.user_id, CONCAT('Preparing to delete password entry for ', OLD.site_name), NOW())
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_insert_password` BEFORE INSERT ON `passwords` FOR EACH ROW SET NEW.created_at = NOW()
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_update_password` BEFORE UPDATE ON `passwords` FOR EACH ROW SET NEW.updated_at = NOW()
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `before_update_pasword` BEFORE UPDATE ON `passwords` FOR EACH ROW set new.updated_at = now()
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL,
  `role_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`role_id`, `role_name`) VALUES
(1, 'Admin'),
(7, 'Analyst'),
(6, 'Developer'),
(10, 'Finance'),
(9, 'HR'),
(3, 'Manager'),
(4, 'Supervisor'),
(5, 'Support'),
(8, 'Tester'),
(2, 'User');

-- --------------------------------------------------------

--
-- Table structure for table `securityquestions`
--

CREATE TABLE `securityquestions` (
  `question_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `question` text NOT NULL,
  `answer_hash` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `securityquestions`
--

INSERT INTO `securityquestions` (`question_id`, `user_id`, `question`, `answer_hash`) VALUES
(1, 1, 'What is your pet\'s name?', 'hashedanswer1'),
(2, 2, 'What is your mother’s maiden name?', 'hashedanswer2'),
(3, 3, 'What was your first car?', 'hashedanswer3'),
(4, 4, 'Where were you born?', 'hashedanswer4'),
(5, 5, 'What is your favorite book?', 'hashedanswer5'),
(6, 6, 'What was your childhood nickname?', 'hashedanswer6'),
(7, 7, 'Who is your favorite teacher?', 'hashedanswer7'),
(8, 8, 'What is your best friend’s name?', 'hashedanswer8'),
(9, 9, 'What is your father’s middle name?', 'hashedanswer9'),
(10, 10, 'What is the name of your first school?', 'hashedanswer10');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `email`, `password_hash`, `role_id`, `created_at`) VALUES
(1, 'admin1', 'admin1@example.com', 'hashedpassword1', 1, '2025-02-02 07:24:35'),
(2, 'user1', 'user1@example.com', 'hashedpassword2', 2, '2025-02-02 07:24:35'),
(3, 'user2', 'user2@example.com', 'hashedpassword3', 3, '2025-02-02 07:24:35'),
(4, 'user3', 'user3@example.com', 'hashedpassword4', 4, '2025-02-02 07:24:35'),
(5, 'user4', 'user4@example.com', 'hashedpassword5', 5, '2025-02-02 07:24:35'),
(6, 'user5', 'user5@example.com', 'hashedpassword6', 6, '2025-02-02 07:24:35'),
(7, 'user6', 'user6@example.com', 'hashedpassword7', 7, '2025-02-02 07:24:35'),
(8, 'user7', 'user7@example.com', 'hashedpassword8', 8, '2025-02-02 07:24:35'),
(9, 'user8', 'user8@example.com', 'hashedpassword9', 9, '2025-02-02 07:24:35'),
(10, 'user9', 'user9@example.com', 'hashedpassword10', 10, '2025-02-02 07:24:35');

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_action_summary`
-- (See below for the actual view)
--
CREATE TABLE `user_action_summary` (
`user_id` int(11)
,`last_action` timestamp
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_latest_update`
-- (See below for the actual view)
--
CREATE TABLE `user_latest_update` (
`user_id` int(11)
,`username` varchar(50)
,`first_password_change` datetime
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_recent_actions`
-- (See below for the actual view)
--
CREATE TABLE `user_recent_actions` (
`log_id` int(11)
,`user_id` int(11)
,`action` varchar(255)
,`timestamp` timestamp
);

-- --------------------------------------------------------

--
-- Structure for view `actions_per_user`
--
DROP TABLE IF EXISTS `actions_per_user`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `actions_per_user`  AS SELECT `activitylogs`.`user_id` AS `user_id`, count(0) AS `action_count` FROM `activitylogs` GROUP BY `activitylogs`.`user_id` ;

-- --------------------------------------------------------

--
-- Structure for view `all_activity_logs`
--
DROP TABLE IF EXISTS `all_activity_logs`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `all_activity_logs`  AS SELECT `activitylogs`.`log_id` AS `log_id`, `activitylogs`.`user_id` AS `user_id`, `activitylogs`.`action` AS `action`, `activitylogs`.`timestamp` AS `timestamp` FROM `activitylogs` ;

-- --------------------------------------------------------

--
-- Structure for view `latest_user_actions`
--
DROP TABLE IF EXISTS `latest_user_actions`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `latest_user_actions`  AS SELECT `a`.`log_id` AS `log_id`, `a`.`user_id` AS `user_id`, `a`.`action` AS `action`, `a`.`timestamp` AS `timestamp` FROM (`activitylogs` `a` join (select `activitylogs`.`user_id` AS `user_id`,max(`activitylogs`.`timestamp`) AS `latest_time` from `activitylogs` group by `activitylogs`.`user_id`) `b` on(`a`.`user_id` = `b`.`user_id` and `a`.`timestamp` = `b`.`latest_time`)) ;

-- --------------------------------------------------------

--
-- Structure for view `user_action_summary`
--
DROP TABLE IF EXISTS `user_action_summary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_action_summary`  AS SELECT `activitylogs`.`user_id` AS `user_id`, max(`activitylogs`.`timestamp`) AS `last_action` FROM `activitylogs` GROUP BY `activitylogs`.`user_id` ;

-- --------------------------------------------------------

--
-- Structure for view `user_latest_update`
--
DROP TABLE IF EXISTS `user_latest_update`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_latest_update`  AS SELECT `u`.`user_id` AS `user_id`, `u`.`username` AS `username`, `first_password_update`(`u`.`user_id`) AS `first_password_change` FROM `users` AS `u` ;

-- --------------------------------------------------------

--
-- Structure for view `user_recent_actions`
--
DROP TABLE IF EXISTS `user_recent_actions`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_recent_actions`  AS SELECT `activitylogs`.`log_id` AS `log_id`, `activitylogs`.`user_id` AS `user_id`, `activitylogs`.`action` AS `action`, `activitylogs`.`timestamp` AS `timestamp` FROM `activitylogs` WHERE `activitylogs`.`timestamp` >= current_timestamp() - interval 7 dayWITH CASCADEDCHECK OPTION  ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `activitylogs`
--
ALTER TABLE `activitylogs`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `category_name` (`category_name`);

--
-- Indexes for table `encryptionmethods`
--
ALTER TABLE `encryptionmethods`
  ADD PRIMARY KEY (`encryption_id`),
  ADD UNIQUE KEY `encryption_type` (`encryption_type`);

--
-- Indexes for table `passwordentries`
--
ALTER TABLE `passwordentries`
  ADD PRIMARY KEY (`entry_id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `encryption_id` (`encryption_id`);

--
-- Indexes for table `passwords`
--
ALTER TABLE `passwords`
  ADD PRIMARY KEY (`entry_id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `encryption_id` (`encryption_id`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`role_id`),
  ADD UNIQUE KEY `role_name` (`role_name`);

--
-- Indexes for table `securityquestions`
--
ALTER TABLE `securityquestions`
  ADD PRIMARY KEY (`question_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `role_id` (`role_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `activitylogs`
--
ALTER TABLE `activitylogs`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=90;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `encryptionmethods`
--
ALTER TABLE `encryptionmethods`
  MODIFY `encryption_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `passwordentries`
--
ALTER TABLE `passwordentries`
  MODIFY `entry_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `passwords`
--
ALTER TABLE `passwords`
  MODIFY `entry_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `role_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `securityquestions`
--
ALTER TABLE `securityquestions`
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `activitylogs`
--
ALTER TABLE `activitylogs`
  ADD CONSTRAINT `activitylogs_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `passwords`
--
ALTER TABLE `passwords`
  ADD CONSTRAINT `passwords_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `passwords_ibfk_2` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `passwords_ibfk_3` FOREIGN KEY (`encryption_id`) REFERENCES `encryptionmethods` (`encryption_id`) ON UPDATE CASCADE;

--
-- Constraints for table `securityquestions`
--
ALTER TABLE `securityquestions`
  ADD CONSTRAINT `securityquestions_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON UPDATE CASCADE;

DELIMITER $$
--
-- Events
--
CREATE DEFINER=`root`@`localhost` EVENT `archive_old_logs` ON SCHEDULE AT '2025-04-04 22:07:24' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    INSERT INTO all_activity_logs (log_id, user_id, action, timestamp)
    SELECT log_id, user_id, action, timestamp FROM activitylogs WHERE timestamp < NOW() - INTERVAL 1 YEAR;

    DELETE FROM activitylogs WHERE timestamp < NOW() - INTERVAL 1 YEAR;
END$$

CREATE DEFINER=`root`@`localhost` EVENT `clear_old_logs` ON SCHEDULE EVERY 1 DAY STARTS '2025-04-04 22:07:39' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    DELETE FROM activitylogs WHERE timestamp < NOW() - INTERVAL 30 DAY;
END$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
