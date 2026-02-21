import { useState } from "react";
import "./App.css";

function App() {
  const [activeSection, setActiveSection] = useState("");
  const [data, setData] = useState([]);
  const [message, setMessage] = useState("");

  const fetchData = async (endpoint) => {
    const response = await fetch(`https://localhost:7250/api/${endpoint}`);
    const result = await response.json();
    setData(result);
    setActiveSection(endpoint);
    setMessage("");
  };

  const registerToCourse = async (courseId) => {
    // Dummy registration example
    await fetch("https://localhost:7250/api/registrations", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        courseId: courseId,
        participantId: 1, // tillfällig test-id
      }),
    });

    setMessage("Successfully registered!");
  };

  return (
    <div className="page">
      <div className="card-wrapper">
        <div className="card" onClick={() => fetchData("courses")}>
          Courses
        </div>
        <div className="card" onClick={() => fetchData("coursesessions")}>
          CourseSessions
        </div>
        <div className="card" onClick={() => fetchData("participants")}>
          Participants
        </div>
        <div className="card" onClick={() => fetchData("teachers")}>
          Teachers
        </div>
      </div>

      {activeSection && (
        <div className="list-section">
          <ul>
            {data.map((item, index) => (
              <li key={index}>
                {Object.values(item).join(" - ")}

                {activeSection === "courses" && (
                  <button
                    className="register-btn"
                    onClick={() => registerToCourse(item.id)}
                  >
                    Register here
                  </button>
                )}
              </li>
            ))}
          </ul>
        </div>
      )}

      {message && <p className="success-msg">{message}</p>}
    </div>
  );
}

export default App;
