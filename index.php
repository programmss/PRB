<html lang='ru'>
<head>
    <meta charset='utf-8'>
    <title>Авторизация</title>
    <style>
        .formRegisterPacient {
            border: 2px solid black;
            width: 230px;
            padding: 20px;
        }
    </style>
</head>
<body>
    <form method="POST" class=formRegisterPacient enctype="multipart/form-data">
        <p>ФИО:</p>
        <input type="text" name="fio">
        <p>Паспортные данные:</p>
        <input type="text" name="passport">
        <p>День рождения:</p>
        <input type="text" name="birthday">
        <p>Пол:</p>
        <input type="text" name="sex">
        <p>Адрес:</p>
        <input type="text" name="address">
        <p>Телефон:</p>
        <input type="text" name="phone">
        <p>Электронная почта:</p>
        <input type="text" name="email">
        <p>Место работы:</p>
        <input type="text" name="placeWork">
        <p>Фото:</p>
        <input type="file" name="photo">
        <p>Номер страхового полиса:</p>
        <input type="text" name="numberPolis">
        <p>Срок действия страхового полиса:</p>
        <input type="text" name="datePolis">
        <p>Страховая компания:</p>
        <input type="text" name="companyPolis">
        <p>Вид страхования:</p>
        <input type="text" name="typePolis"> <br><br>
        <input type="submit" name="register">
    </form>
    <?
        $conn = new mysqli("127.0.0.1:3307", "root", "", "mis");
        if(isset($_POST['register'])) {
            $sqlCheck = "SELECT COUNT(*) FROM user WHERE passport = ".$_POST['passport'];
            $resCheck = $conn -> query($sqlCheck) -> fetch_array()[0];
            
            if($resCheck == 0) {
                $photo = addslashes(file_get_contents($_FILES['photo']['tmp_name']));

                $sqlInsertUser = "INSERT INTO user(user_id, fio, passport, birthday, sex, address, phone, email, place_work, photo) VALUES(null, " .chr(39).$_POST["fio"].chr(39). ", " . $_POST["passport"] . 
                    ", ".chr(39).$_POST["birthday"].chr(39).", ".chr(39).$_POST["sex"].chr(39).", ".chr(39).$_POST["address"].chr(39).", ".chr(39).$_POST["phone"].chr(39).",".chr(39).$_POST["email"].chr(39).", " .chr(39).$_POST["placeWork"].chr(39).", ".chr(39).$photo.chr(39).")";
                $resInsertUser = $conn->query($sqlInsertUser);
                $sqlUserId = "SELECT user_id FROM user WHERE passport = ".$_POST["passport"];
                $resUserId = $conn -> query($sqlUserId) -> fetch_array()[0];

                $sqlInsertPolis = "INSERT INTO polis(polis_id, user_id, number, polis_type, end_date, company) VALUES(null, ".$resUserId.", ".$_POST["numberPolis"].", ".chr(39).$_POST['typePolis'].chr(39).", ".chr(39).$_POST["datePolis"].chr(39).", ".chr(39).$_POST["companyPolis"].chr(39).")";
                $resInsertPolis = $conn -> query($sqlInsertPolis);  


                $sqlMedCardNumberMax = "SELECT MAX(medical_card_number) FROM medical_card";
                $resMedCardNumberMax = $conn -> query($sqlMedCardNumberMax) -> fetch_array()[0] + 1;

                $sqlInsertMedCard = "INSERT INTO medical_card (medical_card_id, user_id, medical_card_number, date_release) VALUES(null, ".$resUserId.", ".$resMedCardNumberMax.", DEFAULT)";
                $resInsertMedCard = $conn -> query($sqlInsertMedCard);
                echo $sqlInsertMedCard;
                header("Location: index.php");
            }
            else { echo "Уже существует запись"; }
        }
    ?>
</body>
</html>