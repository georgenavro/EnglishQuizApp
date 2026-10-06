import React,{useState} from "react";
import Login from "./Login/login";
import Register from "./Login/register";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import QuestionsAnswers from "./GenerateTest/QuestionsAnswers.jsx";
import AboutMe from "./GenerateTest/AboutMe.jsx";
import TestResults from "./GenerateTest/TestResults.jsx";
import ProtectedRoute from "./Auth/ProtectedRoute.jsx";
import {AuthProvider} from "./Auth/AuthContext.jsx";
import Header from "./Layout/Header.jsx";
import Footer from "./Layout/Footer.jsx";
import { ImUserTie } from "react-icons/im";
import NavBar from "./Layout/NavBar.jsx";
import GeneratedTest from "./GenerateTest/GeneratedTest.jsx";
import Admin_Dashboard from "./Admin/Admin_Panel.jsx";
import Admin_NavigationBar from "./Layout/AdminNavBar.jsx";
import AddRemove_Data from "./Admin/AddRemove_Data.jsx";


function App(){
  const title = "English Grammar Test Generator";
  
  return (
      <AuthProvider>
        <Router>
        <Routes>
        <Route path="/login" element={ <div><Header title={title}/><Login/><Footer/></div>} />        {/* Login Page */}
        <Route path="/register" element={<div><Header title={title}/><Register /><Footer/></div>} /> {/* Register Page */}
        <Route path="/admin_dashboard" element={<ProtectedRoute requiredRole={["Admin"]}><div><Admin_NavigationBar/><Header title={title}/><Admin_Dashboard/><Footer/></div></ProtectedRoute>} />
        <Route path="/add_data" element={<ProtectedRoute requiredRole={["Admin"]}><div><Admin_NavigationBar/><Header title={title}/><AddRemove_Data/><Footer/></div></ProtectedRoute>} />
        
        
        <Route path="/" element={<ProtectedRoute requiredRole={["User","Admin"]}><NavBar/><Header title={title}/><QuestionsAnswers /><Footer/></ProtectedRoute>} />
        <Route path="/GeneratedTest" element={<ProtectedRoute requiredRole={["User","Admin"]}><NavBar/><Header title={title} className={"HeaderGeneratedTest"}/><GeneratedTest /><Footer/></ProtectedRoute>} /> 
        <Route path="/AboutMe" element={<ProtectedRoute requiredRole={["User","Admin"]}><NavBar/><Header icon={<ImUserTie/>} title="George Navrozidis"/><AboutMe /><Footer/></ProtectedRoute>} /> 
        <Route path="/TestResults" element={<ProtectedRoute requiredRole={["User","Admin"]}><NavBar/><Header title={title}/><TestResults /><Footer/></ProtectedRoute>} /> 
        </Routes>
        </Router> 
        </AuthProvider>
  );
}

export default App;

