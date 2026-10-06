import React, {useState} from "react";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import "./../../../public/register.css";
import { FaUserAlt } from "react-icons/fa";
import { BiSolidLock } from "react-icons/bi";
import { ImUserTie } from "react-icons/im";

function Register(){
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [name, setFullName] = useState("");

    const navigate = useNavigate();
    const [error, setError] = useState("");
   
    function handleUsername(event){
      const value = event.target.value;
      setUsername(value);
    }

    function handlePassword(event){
      const value = event.target.value;
      setPassword(value);
      if(confirmPassword != value){
        setError("Your confirm Password don't match with the password");
      }
      else{
        setError("");
      }
    }
 
    function handleName(){
      const value = event.target.value;
      setFullName(value);
    }

    function handleConfirmPassword(){
      const value = event.target.value;
      setConfirmPassword(value);
      
      if(password != value){
        setError("Your confirm Password don't match with the password");
      }
      else{
        setError("");
      }

    }

   async function handleRegistretion(event){
      event.preventDefault();

       try{
        const registerData = {
          Name: name,
          Username: username,
          Password: password,
          UsersTypeID: 2
         };
          const response = await axios.post("http://localhost:8095/Users/Add", registerData, {
            headers: {
              "Content-Type": "application/json",  // Ensure JSON content type is set
            }});
          
          navigate("/");
          
        } catch (error) {
        
            if(error.status == 400){
            setError("Both username and password are required.");}
            else{
            setError("Username is already exist. Please try again with an other username");}
        }

    }

    function goBack(){
      navigate("/login");
    }

  
  return  <div className="registerForm">
  <h1>Sign Up</h1>
  <p>{error}</p>
  <form>
    <div name="fullName" 
    className="registerInputs changeColor">
       <span className="icon"><ImUserTie /></span>
    <input onChange={handleName} type="text" placeholder="Full Name" />
    </div>

    <div name="User" 
    className="registerInputs">
       <span className="icon"><FaUserAlt /></span>
    <input onChange={handleUsername} type="text" placeholder="Username" />
    </div>

    <div name="password" 
    className="registerInputs">
       <span className="icon"><BiSolidLock /></span>
    <input onChange={handlePassword} type="password" placeholder="Password" />
    </div>

    <div name="confPassword" 
    className="registerInputs">
       <span className="icon"><BiSolidLock /></span>
    <input onChange={handleConfirmPassword} type="password" placeholder="Confirm Password" />
    </div>

    <button 
    className="registerInputs typeBut"
     onClick={handleRegistretion} name="btnReg">Register</button>

    <button 
     className="registerInputs typeBut changeColor"
      onClick={goBack} name="btnSignIn">Sign In</button>
  </form>
  </div>
}

export default Register;
