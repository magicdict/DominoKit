package ;

import org.hibernate.validator.constraints.*;
import javax.persistence.*;

@Entity
public class Account {

    //User
    private String User ;
    public void setUser(String User){
        this.User = User;
    }
    public String getUser(){
        return this.User;
    }

    //Password
    private String Password ;
    public void setPassword(String Password){
        this.Password = Password;
    }
    public String getPassword(){
        return this.Password;
    }

    //Email
    private String Email ;
    public void setEmail(String Email){
        this.Email = Email;
    }
    public String getEmail(){
        return this.Email;
    }

    //CompanyId
    private String CompanyId ;
    public void setCompanyId(String CompanyId){
        this.CompanyId = CompanyId;
    }
    public String getCompanyId(){
        return this.CompanyId;
    }

}
