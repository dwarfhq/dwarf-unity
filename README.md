# ✨ Unity Utilities ✨

## 🌱 Prerequisites for setup

-   [Unity](https://unity.com/download) with a version equal to or higher than the one specified for the `unity` property in [package.json](./package.json)

## 🧰 Project initiation

### Development

1. On the command line, navigate to the `/Packages` directory of the Unity project you want to embed the package in for development. This can be any project satisfying the [prerequisites](#-prerequisites-for-setup).
2. Create a subdirectory with the name specified in the `name` property in [package.json](./package.json)

```sh
mkdir dk.dwarf.utilities
```

3. Clone this repository into the newly created directory:

```sh
git clone git@github.com:dwarfhq/dwarf-unity.git dk.dwarf.utilities
```

### Usage

1.  In your Unity project, open **Window > Package Manager**
2.  Click the **+** in the upper left corner
3.  Select **Add package from git URL...**
4.  Paste the [HTTPS URL](https://github.com/dwarfhq/dwarf-unity.git) for this repository and select **Add**
5.  The package is now added in the _Packages_ directory of your project

## 👨‍💻 Developers

-   JSK - Jakob Skov Olsen
-   AFJ - Aleksander Fjellvang
-   FWE - Flemming Westberg

## 📘 About the project

-   Unity package containing utilities and design pattern implementations

---

Developed with ❤️ by ▽ **DWARF A/S** in 2023

---
