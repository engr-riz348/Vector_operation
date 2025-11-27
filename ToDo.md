## 📝 Project To-Do List: Inventory Management System (IMS)

---

### 1.  planificación del proyecto (Fase 1) 🗓️

* **Define Scope & Requirements:**
  * [x] Finalize **Product Attributes** for all types.
  * [x] Detail **Supplier** information required (ID, Name, Contact).
  * [x] Define **Low Stock Threshold** (e.g., quantity **$< 10$**).
  * [x] Define **Expiry Alert Window** (e.g., within 7 days).
* **Architectural Planning:**
  * [x] Sketch the basic **Inheritance structure** (Base `Product` **$\rightarrow$** Derived `ElectronicProduct`, `GroceryProduct`).
  * [x] Plan the `Inventory` class's internal structure (e.g., using a `List<Product>` or `Dictionary<int, Product>`).
  * [x] Draft the  **Requirements Specification Document** .

---

### 2. System Design (Fase 2) 📐

* **UML & Flow Diagrams:**
  * [ ] Draw the **Use Case Diagram** for key actors (Store Manager).
  * [ ] Create the **Class Diagram** (must include `Product`, `Supplier`, `ElectronicProduct`, `GroceryProduct`, `Inventory`).
  * [ ] Design the **Main Menu Flow** (System Navigation Diagram).
* **Function Detail:**
  * [ ] Write **Pseudocode** for `AddProduct()`, `UpdateQuantity()`, and `DisplayLowStock()`.
  * [ ] Outline the **Input Validation Strategy** (e.g., checking for negative quantity, non-numeric ID input).

---

### 3. Code Setup & Architecture (Fase 3) 🏗️

* **Project Setup:**
  * [x] Create the C# **WinForms Application** project.
* **Base Classes:**
  * [x] Code the **`Supplier`** class (Properties, Constructor).
  * [x] Code the **`Product`** base class (Properties: ID, Name, Price, Quantity).
  * [x] Implement **Encapsulation** (private fields, public properties) in base classes.
* **Derived Classes (Inheritance):**
  * [x] Code **`ElectronicProduct`** (inherits `Product`, adds `WarrantyMonths`).
  * [x] Code **`GroceryProduct`** (inherits `Product`, adds `ExpiryDate`).
* **Core Inventory Class:**
  * [x] Implement the **`Inventory`** class (stores the list of products).
* **Helper Functions:**
  * [x] Code a reusable function for **safe numeric input** and basic validation.
  * [x] Code a function for **formatted product output** (displaying product details neatly).

---

### 4. Core Functionality Development (Fase 4) ⚙️

* **CRUD Operations:**
  * [x] Implement **`AddProduct()`** (handles category selection and unique ID generation).
  * [x] Implement **`SearchProduct()`** by ID.
  * [x] Implement  **`UpdateQuantity()`** .
  * [x] Implement  **`DeleteProduct()`** .
  * [x] Implement **`DisplayProducts()`** (shows all products and their categories).
* **Alerts & Validation:**
  * [x] Implement **`CheckLowStock()`** logic.
  * [x] Implement **`CheckExpiry()`** logic for grocery items.
  * [x] Integrate **Input Validation** into all user interaction points.

---

### 5. Menu Development & Integration (Fase 5) 🖥️

* **Menu Interface:**
  * [x] Develop the **Main Menu loop** and `switch-case` structure.
  * [x] Create the **Product Addition Sub-menu** (to select Electronic or Grocery).
* **Integration:**
  * [x] **Connect** all `Inventory` methods to the corresponding menu options.
  * [x] Implement the **Navigation Logic** (`Press Enter to return to Main Menu...`).
  * [x] Ensure **Polymorphism** is used when displaying product details (e.g., calling a virtual `DisplayDetails()` method).

---

### 6. Testing & Debugging (Fase 6) 🐞

* **Unit Testing:**
  * [ ] Test `AddProduct()` with  **both product types** .
  * [ ] Test **ID validation** (search/delete with non-existent ID).
  * [ ] Test **Quantity Update** (e.g., adding negative amount, setting to zero).
  * [ ] Test **Low Stock alert trigger** (add product below the defined threshold).
  * [ ] Test **Expiry alert trigger** (add a product with an expiry date *near* the current date).
* **System Testing:**
  * [ ] Perform an **end-to-end integration test** of a complete user session.
  * [ ] **Fix all identified bugs** and refine input prompts.

---

### 7. Documentation & Report Creation (Fase 7) 📄

* **Report Sections:**
  * [x] Finalize the  **Project Proposal** .
  * [x] Document the **System Design** (UML explanation, class relationships).
  * [x] Write the **User Manual** (how to run the program and use all features).
  * [x] Add **Final Output Screenshots** to the report.
  * [x] **Format** the complete document according to academic standards.

---

### 8. Finalization (Fase 8) 🚀

* [ ] **Code Cleanup** (comments, formatting, variable naming).
* [ ] **Generate Project Files** ZIP folder for submission.
* [ ] Create the **PowerPoint Presentation** outline/slides.
* [ ] Prepare the **Verbal Demo Script** and practice the flow.
* [ ] **Submit** all final deliverables.
