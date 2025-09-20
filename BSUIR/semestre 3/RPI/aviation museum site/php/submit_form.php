<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Получаем данные из формы
    $name = htmlspecialchars($_POST['name']);
    $email = htmlspecialchars($_POST['email']);
    $phone = htmlspecialchars($_POST['phone']);
    $subject = htmlspecialchars($_POST['subject']);
    $message = htmlspecialchars($_POST['message']);
    $source = htmlspecialchars($_POST['source']);
    $privacy_agreement = isset($_POST['privacy']) ? true : false;

    // Проверка на согласие с политикой конфиденциальности
    if (!$privacy_agreement) {
        echo "Вы должны согласиться с политикой конфиденциальности.";
        exit;
    }

    // Сообщение для отправки на email
    $to = "minsktf@gmail.com";
    $subject_email = "Новое сообщение с формы обратной связи";
    $message_email = "
    Имя: $name\n
    Email: $email\n
    Телефон: $phone\n
    Тема: $subject\n
    Сообщение:\n$message\n
    Как узнали: $source
    ";

    // Отправка email
    $headers = "From: noreply@yourdomain.com" . "\r\n" .
               "Reply-To: $email" . "\r\n" .
               "X-Mailer: PHP/" . phpversion();

    if (mail($to, $subject_email, $message_email, $headers)) {
        echo "<h1>Спасибо за ваше сообщение! Мы свяжемся с вами в ближайшее время.</h1>";
    } else {
        echo "<h1>Произошла ошибка при отправке сообщения. Пожалуйста, попробуйте снова.</h1>";
    }
} else {
    echo "Ошибка! Запрос не был отправлен корректно.";
}
?>
