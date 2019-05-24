/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.gui;

import client.Client;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;

/**
 *
 * @author Cole
 */
public class RegNewAcctGUI implements IGUI
{

    private Pane root;
    private TextField username;
    private TextField password;
    private TextField email;
    private Button confirmBtn;

    private final String TITLE = "Register New Account";

    public RegNewAcctGUI()
    {
        this.root = new Pane();
        this.username = new TextField();
        this.password = new TextField();
        this.email = new TextField();
        this.confirmBtn = new Button();
    }

    @Override
    public Scene setup()
    {
        int x = 25;
        int y = 20;
        int width = 200;

        username.setLayoutX(x);
        username.setLayoutY(y);
        username.setPrefWidth(width);
        username.setText("username");

        password.setLayoutX(x);
        password.setLayoutY(username.getLayoutY() + 30);
        password.setPrefWidth(width);
        password.setText("password");

        email.setLayoutX(x);
        email.setLayoutY(password.getLayoutY() + 30);
        email.setPrefWidth(width);
        email.setText("enter email address");

        confirmBtn.setLayoutX(x + 70);
        confirmBtn.setLayoutY(email.getLayoutY() + 30);
        confirmBtn.setText("Confirm");

        root.getChildren().add(username);
        root.getChildren().add(password);
        root.getChildren().add(email);
        root.getChildren().add(confirmBtn);

        Scene scene = new Scene(root, 250, 150);
        return scene;
    }

    @Override
    public String getTitle()
    {
        return TITLE;
    }

    public boolean verifyFields(Client client)
    {
        boolean result = false;
        Alert a;
        if (username.getText().length() > 15 || username.getText().contains("-"))
        {
            a = new Alert(AlertType.ERROR);
            a.setContentText("ERROR: Invalid username.");
            a.show();
        }
        else if (password.getText().length() > 60 || password.getText().contains("-"))
        {
            a = new Alert(AlertType.ERROR);
            a.setContentText("ERROR: Invalid password.");
            a.show();
        }
        else if (!validEmail(email.getText()) || email.getText().contains("-"))
        {
            a = new Alert(AlertType.ERROR);
            a.setContentText("ERROR: Invalid email.");
            a.show();
        }
        else
        {
            a = new Alert(AlertType.CONFIRMATION);
            String msg = "&register-" + username.getText() + "-" + password.getText() + "-" + email.getText();

            String str = client.sendMessage(msg);
            System.out.println(str);
            if (str.contains("ERROR:"))
            {
                a.setAlertType(AlertType.ERROR);
                a.setContentText(str);
                a.show();
                result = false;
            }
            else
            {
                a.setContentText("Account successfully registered.");
                a.show();

                client.setUsername(username.getText());
                result = true;
            }

        }
        return result;
    }

    // verify emailtext
    private boolean validEmail(String emt)
    {
        boolean result = true;
        if (emt.length() > 255)
        {
            result = false;
        }
        else
        {
            try
            {
                InternetAddress address = new InternetAddress(emt);
                address.validate();
            }
            catch (AddressException ex)
            {
                result = false;
            }
        }

        return result;
    }

    public Button getConfirmBtn()
    {
        return confirmBtn;
    }

    @Override
    public void closeGUI()
    {
        System.exit(0);
    }

}
