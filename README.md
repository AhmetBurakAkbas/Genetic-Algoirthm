# Genetic Algorithm Optimization – Sphere Function in C#

This project implements a **Genetic Algorithm (GA)** in C# to optimize the well-known **sphere function**, a standard benchmark for continuous optimization:

\[
f(\mathbf{x}) = \sum_{i=1}^{n} x_i^2 \quad \text{for } x_i \in (-\infty, \infty)
\]

The objective is to **minimize** the function value, ideally reaching **f(x) = 0** at the global minimum **x = [0, 0, ..., 0]**.

---

## 🧠 Algorithm Features

- Customizable **population size**, **mutation rate**, **crossover rate**, and **number of generations**
- Works on **n-dimensional** vectors
- Real-valued encoding of solutions
- Supports different selection, crossover, and mutation strategies
- Displays best fitness value per generation

---

## 🚀 How It Works

1. **Initialize** a population of random vectors within a defined search space.
2. **Evaluate** each individual's fitness using the sphere function.
3. Apply **selection**, **crossover**, and **mutation** to produce the next generation.
4. Repeat for a number of generations or until the solution converges.

---

## 🛠️ Configuration Parameters

| Parameter         | Description                          |
|------------------|--------------------------------------|
| `populationSize` | Number of candidate solutions        |
| `dimensions`     | Number of variables (n in x₁, x₂...) |
| `mutationRate`   | Probability of mutation              |
| `crossoverRate`  | Probability of crossover             |
| `generations`    | Number of iterations (epochs)        |
| `rangeMin/Max`   | Variable bounds (e.g., -100 to +100) |

---

## 📷 Screenshots
*(You can add a screenshot of the output window or graph if available.)*

---

## 🧪 Example Output


