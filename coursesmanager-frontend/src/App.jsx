import { useEffect, useState } from "react";

function App() {
  const [courses, setCourses] = useState([]);
  const [title, setTitle] = useState("");

  // Hämtar alla kurser från API:et
  useEffect(() => {
    fetch("https://localhost:7250/api/courses")
      .then((res) => res.json())
      .then((data) => setCourses(data))
      .catch((err) => console.error(err));
  }, []);

  // Skapar en ny kurs
  const createCourse = async () => {
    const newCourse = {
      courseCode: "FRONT101",
      title: title,
      description: "Created from frontend",
    };

    await fetch("https://localhost:7250/api/courses", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newCourse),
    });

    window.location.reload();
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Courses</h1>

      <input
        placeholder="Course title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />

      <button onClick={createCourse}>Create Course</button>

      <ul>
        {courses.map((course) => (
          <li key={course.id}>
            {course.courseCode} - {course.title}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
