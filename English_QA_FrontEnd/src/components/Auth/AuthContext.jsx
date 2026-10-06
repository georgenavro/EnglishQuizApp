import React, { createContext, useContext, useState} from "react";
import {jwtDecode} from "jwt-decode";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(() => {
        const token = localStorage.getItem("token");
        if (token) {
            const decodedToken = jwtDecode(token);
            const currentTime = Date.now() / 1000; // Current time in seconds
            
            // Check if the token has expired
            if (decodedToken.exp < currentTime) {
                localStorage.removeItem("token");
                window.alert("Token is Expired. Please log in again.");
                return false; // Token is expired, set the user as not authenticated
            } else {
                return true; // Token is valid, set the user as authenticated
            }
        }
        return false; // No token found, set the user as not authenticated
    });

    return (
        <AuthContext.Provider value={{ isAuthenticated,setIsAuthenticated}}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    return useContext(AuthContext);
};