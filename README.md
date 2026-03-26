# Unity Inventory System

A lightweight, modular inventory framework for Unity projects using **ScriptableObjects**. This system is designed for high performance and a clean separation of data and logic, making it easy to integrate into any 2D or 3D game.

---

## 📦 Included Scripts

- ItemData.cs
- InventoryItem.cs (A simple helper class to track how many of a specific item are in a slot.)
- InventoryManager.cs (The "Brain" of the system. It handles adding, removing, and finding items.)

---

## ✨ Features

* **ScriptableObject Driven:** Create new items as persistent assets in the Editor without touching a single line of code.
* **Stacking System:** Toggleable stacking with customizable "maxStackSize" per item.
* **Decoupled Architecture:** Uses C# Actions (Events) to trigger UI updates, keeping game logic and visuals completely separate.
* **Dictionary Lookups:** Utilizes a Dictionary for fast $O(1)$ item lookups to ensure performance remains stable as the inventory grows.
* **Template Ready:** Minimal dependencies; just drop the scripts into your project and start building.

---

## 🧠 Design Notes

The system follows **Data-Oriented** principles by using "ItemData" ScriptableObjects. Instead of every "Health Potion" in your game holding its own unique strings and icons, they all point to a single memory address. 

By separating the **Item Definition** ("ItemData") from the **Item Instance** ("InventoryItem"), the system remains memory-efficient and easy to save/load. The "InventoryManager" handles the collection logic, while the "OnInventoryChanged" event allows any UI element to listen for changes without being tightly coupled to the manager.

---

## 🧩 How To Use

1.  **Create an Item:** In your Project window, right-click and go to Create > Inventory > Item. Fill in the name, description, and icon.
2.  **Setup Manager:** Attach the "InventoryManager.cs" script to a GameObject in your scene (e.g., a "GameManager" or "Player").
3.  **Adding Items:** To add an item via code (e.g., when a player walks over a pickup), simply call:
    ```csharp
    inventoryManager.AddItem(itemDataReference);
    ```
4.  **UI Updates:** Have your UI scripts subscribe to the static event to refresh the display:
    ```csharp
    InventoryManager.OnInventoryChanged += MyUpdateUIFunction;
    ```

---

## 🚀 Possible Extensions

* **Drag & Drop:** Implement a "SlotUI" script to handle visual movement between grid spaces.
* **Weight System:** Add a "weight" property to "ItemData" and a "maxWeight" check in the "AddItem" method.
* **Serialization:** Add "[System.Serializable]" to your data structures to easily convert the inventory to JSON for save files.
* **Rarity System:** Add an "Enum" for Rarity (Common, Rare, Legendary) to change UI border colors dynamically.

---

## 🛠 Unity Version

Tested in Unity6+ (should also work without problems in the newer versions)

---

## 📜 License

MIT
