/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.database;

import java.sql.*;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;

/**
 *
 * @author Cole
 */
public class DBAccounts
{

    private static final String DB_URL = "jdbc:mysql://localhost:3306/mychatroom?zeroDateTimeBehavior=convertToNull";
    private static final String USER = "root";
    private static final String PASS = "root";

    /*
    
        USERNAME varchar(15) (primary key)
        PASSWORD varchar(60)
        EMAIL varchar(255)
    
     */

    public String verifyAccount(String username, String password)
    {
        String result = "SUCCESS: Login successful.";
        try
        {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
            Statement stmt = conn.createStatement();
            
            // check username
            boolean ucheck = checkInformation(conn, stmt, username, "USERNAME");
            
            if(!ucheck)
            {
                result = "ERROR: Invalid username.";
                conn.close();
                return result;
            }
            
            // check password
            boolean pcheck = checkInformation(conn, stmt, password, "PASSWORD");
            
            if(!pcheck)
            {
                result = "ERROR: Invalid password.";
                conn.close();
                return result;
            }
            
            conn.close();
        }
        catch (ClassNotFoundException | SQLException e)
        {
           result = e.toString();
        }

        return result;
    }
    
    // sends the username, password, and email to the accounts table
    // it is assumed that all provided information has been checked prior to this point
    public String registerAccount(String username, String password, String email)
    {
        String result = "SUCCESS: Account successfully registered.";
        try
        {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
            Statement stmt = conn.createStatement();
            
            // check username
            boolean ucheck = checkInformation(conn, stmt, username, "USERNAME");
            
            if(ucheck)
            {
                result = "ERROR: Username already exists in database.";
                conn.close();
                return result;
            }
            
            stmt.executeUpdate(String.format("INSERT INTO MYCHATROOM.ACCOUNTS VALUES ('%s', '%s', '%s')", username, password, email));
            
            conn.close();
        }
        catch (ClassNotFoundException | SQLException e)
        {
            System.out.println(e.toString());
        }
        return result;
    }
    
    private boolean checkInformation(Connection conn, Statement stmt, String info, String column)
    {
        try
        {
            ResultSet rs = stmt.executeQuery(String.format("SELECT %s FROM MYCHATROOM.ACCOUNTS WHERE %s = '%s'", column, column, info));
            while(rs.next())
            {
                if(rs.getString(column).equals(info))
                {
                    return true;
                }
            }
        }
        catch (SQLException e)
        {
            System.out.println(e.toString());
        }
        
        return false;
    }
    
    
}
