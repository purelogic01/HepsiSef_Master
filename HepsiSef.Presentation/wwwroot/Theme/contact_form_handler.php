<?php
/**
 * File Name: contact_form_handler.php
 *
 * Send message function to process contact form submission
 *
 */
if(isset($_POST['email'])):

    $name = $_POST['name'];
    $email = $_POST['email'];
    $number = $_POST['number'];
    $message = $_POST['message'];
    $address = "demo@demo.com";

    if(get_magic_quotes_gpc()) {
        $message = stripslashes($message);
    }

    $e_subject = 'You Have Received a Message From ' . $name . '.';

    if(!empty($subject))
    {
        $e_subject = $subject . '.';
    }

    $e_body = 	"You have Received a message from: "
        .$name
        . "\n"
        . "Phone Number: "
        . $number
        . "\r\n\n"
        ."Their additional message is as follows."
        ."\r\n\n";

    $e_content = "\" $message \"\r\n\n";

    $e_reply = 	"You can contact "
        .$name
        . " via email, "
        .$email;

    $msg = $e_body . $e_content . $e_reply;

    if(mail($address, $e_subject, $msg, "From: $email\r\nReply-To: $email\r\nReturn-Path: $email\r\n","-f $address"))
    {
        echo "Message Sent Successfully!";
    }
    else
    {
        echo "Server Error:  mail method failed!";
    }
else:
    echo "Invalid Request ";
endif;

die;




?>