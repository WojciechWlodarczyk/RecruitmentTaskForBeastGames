# This project was made by Wojciech Włodarczyk

# Controls
### Movement
- **W**: Move forward
- **A**: Move left
- **S**: Move backward
- **D**: Move right
- **Shift**: Sprint

### Camera
- **Mouse Movement**: Look around

### Interactions
- **q**: Collect item
- **tab**: open/close equipment menu

### How to add new behaviour in editor, when crafting failed or successed?
1. Find an object in the scene => GameManager/CraftingManager
2. In possible crafting you can add UnityEvent, when crafting certain items failed or succeeded