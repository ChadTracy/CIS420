  <?php
    $name=$_REQUEST['name']; 
    $email=$_REQUEST['email']; 
    $message=$_REQUEST['message']; 
    $subject=$_REQUEST['subject'];
	$copy=$_REQUEST['copy'];
    if (($name=="")||($email=="")||($message=="")) // if blank
        { 
			echo '<script type="text/javascript"> window.location = "Error.cshtml" </script>'; 
        }
	if (strpos($email,'@') !== FALSE) //if email contains '@'
		{
			if ($copy == FALSE) // User did NOT request a copy
			{
				$from="From: $name<$email>\r\nReturn-path: $email"; 
				mail("hello@quinnbanet.com", $subject, $message, $from); 
				echo '<script type="text/javascript"> window.location = "ThankYou.cshtml" </script>';	
			}
			if ($copy == TRUE) // User requetsed a copy
			{
				$from="From: $name<$email>\r\nReturn-path: $email"; 
				mail("hello@quinnbanet.com", $subject, $message, $from);
				mail($email, $subject, $message, $from);				
				echo '<script type="text/javascript"> window.location = "ThankYou.cshtml" </script>';	
			}
		}
    else{ // if email does not contain '@' or any other exception
			echo '<script type="text/javascript"> window.location = "Error.cshtml" </script>';
        }   
  ?>