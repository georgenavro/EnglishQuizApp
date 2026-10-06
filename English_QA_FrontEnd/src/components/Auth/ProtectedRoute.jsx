import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthContext";
import { jwtDecode } from "jwt-decode";

const ProtectedRoute = ({ children, requiredRole }) => {
    const { isAuthenticated } = useAuth();
    const token = localStorage.getItem("token");
    
    var role = "";
    if(token == null){
        return <Navigate to="/login" replace />;
    }
    else{
        const jwtToken = jwtDecode(token);
        const roleclaim = Object.keys(jwtToken).find(key=>key.includes("role"));
        role = jwtToken[roleclaim];
        
    }
    if (!isAuthenticated) {
        return <Navigate to="/login" replace />;
    }
    if (isAuthenticated && !requiredRole.includes(role)) {
    return <Navigate to="/" replace />; // redirect if role is not allowed
    }
    

    return children;
};

export default ProtectedRoute;