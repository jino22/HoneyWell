import { useState } from "react";
import "./loginpage.css"
import validator from "validator";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Button from "@mui/material/Button";
import axios from "axios";
import { useNavigate } from "react-router-dom";
// import Dashboard from "./Dashboard";

function FormValidation() {
    const navigateTo = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [emailError, setEmailError] = useState(false);
    const [passwordError, setPasswordError] = useState(false);


    const authenticate = () => {
        const userData = {
            id: email.trim(),
            password,
        };

        axios
            .post("https://datafactory001.azurewebsites.net/login", userData)
            .then((response) => {
                console.log(response);
                navigateTo('/dashboard')
            })
            .catch(error => toast.error("loginfailed: Invalid username and password"));
    };

    const validateEmail = (e) => {
        setEmail(e.target.value);
        if (!validator.isEmail(email)) {
            setEmailError(true);
        }
        else {
            setEmailError(false);
        }
    };

    const validatePassword = (e) => {
        setPassword(e.target.value);
        if (!validator.isStrongPassword(password)) {
            setPasswordError(true);
        }
        else {
            setPasswordError(false);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (emailError && passwordError) {
            toast.error("loginfailed: Invalid username and password");
        } else {
            authenticate();
        }
    };

    return (
        <div className="container" style={{ padding: "20px" }}>
            <form className="formdesign"  >
                <h3 style={{ color: "red" }}>Honeywell</h3>
                <h4>Digital Factory Login</h4>
                <div className="email">
                <label >Email address*</label>
                </div>

                <div>
                    <input
                        type="text"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => validateEmail(e)}
                        onPasteCapture={(e) => validateEmail(e)} />
                </div>

                <div className="pwd">
                <label >Password*</label>
                </div>

                <div>
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => validatePassword(e)}
                        onPaste={(e) => validatePassword(e)} />
                </div>
                <br />
                <Button style={{ width: "30%", margin: "-20px auto" }} className="bttn"
                 onClick={handleSubmit}  variant="outlined">Login{" "}
                </Button>
            </form>
            <ToastContainer />
        </div>
    );
}
export default FormValidation;