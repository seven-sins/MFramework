### v0.0.12

---

* [ ] 支持AssetBundle中加载的资源
* [ ] 支持多个AssetBundle平台的Build
* [ ] AssetBundle依赖的问题处理

### v0.0.11

---

* [x] 完成AssetBundle简单管理

### v0.0.10

---

* [x] prefab的卸载支持
* [x] 异步加载支持
* [x] 学习AssetBundle相关内容

### v0.0.9

---

* 显示当前加载资源

### v0.0.8

---

* 引用计数

### v0.0.7

---

* 卸载Resources.Load加载的资源

### v0.0.6

---

* 学习静态this扩展
* 应用静态this扩展

### v0.0.5

---

* [x] 应用单例模板

* [ ] 学习单元测试

### v0.0.4

---

* 简单单例

  ``` csharp
  public class SingletonExample {
      
      private static SingletonExample mInstance;
      
      private SingletonExample() { }
      
      public static SingletonExample Instance {
          get {
              if(mInstance == null) {
                  mInstance = new SingletonExample();
              }
              return mInstance;
          }
      }
  }
  
  ```

* 单例模板

  ```csharp
  public abstract class Singleton<T> where T : Singleton<T> {
          private static T mInstance;
  
          protected Singleton() { }
  
          public static T Instance {
              get {
                  if (mInstance == null) {
                      // 反射获得无参构造函数
                      ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                      ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                      if(ctor == null) {
                          throw new Exception("Non-public ctor() not found!");
                      }
                      mInstance = ctor.Invoke(null) as T;
                  }
                  return mInstance;
              }
          }
      }
  ```

  

* 使用模板

  ```csharp
  public class SingletonExample : Singleton<SingletonExample> {
  
          private SingletonExample() {
              Debug.Log("singleton Example ctor");
          }
  
  #if UNITY_EDITOR
          [UnityEditor.MenuItem("MFramework/Example/16.SingletonExample", false, 16)]
  #endif
          static void MenuClicked() {
              var instance = SingletonExample.Instance;
  
              instance = SingletonExample.Instance;
          }
      }
  ```

  

### v0.0.3

---

* Manager Of Managers雏形完成

### v0.0.2

---

* 第一次整理后的备份

### v0.0.1

---

* 第一次整理前的备份

